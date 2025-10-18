using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using puzzle.utils;

namespace puzzle
{
    public partial class jogo : Form
    {
        private dadosJogo dados;
        private bool arrastando = false;
        private PictureBox pecaSelecionada = null;
        private Point offset;
        List<PointF> encaixes = new List<PointF>();
        Point pontoTela;
        Point pontoForm;
        private Panel fundoCinza;


        public jogo(dadosJogo dados)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            this.dados = dados;

            tela dadosTela = new tela(dados.imgPath);

            var (larguraPeca, alturaPeca, colunas, linhas) = CalcularDimensoesPecas(dados.dificuldade, dadosTela.image);

            List<Bitmap> pecas = separarImagemEmPecas(dadosTela.image, larguraPeca, alturaPeca, colunas, linhas);


            //fundo cinza
            fundoCinza = new Panel();

            fundoCinza.Size = new Size(dadosTela.imgLargura, dadosTela.imgAltura);
            

            this.Controls.Add(fundoCinza);

            int centroX = (this.ClientSize.Width - fundoCinza.Width) / 2;
            int centroY = (this.ClientSize.Height - fundoCinza.Height) / 2;

            fundoCinza.Anchor = AnchorStyles.None;
            fundoCinza.Location = new Point(centroX, centroY);

            if (dados.imgAjuda)
            {
                Bitmap imgPB = imagemUtils.ConverterImagemParaPretoEBranco(Image.FromFile(dados.imgPath));
                Bitmap imgPBR = imagemUtils.redimensionarImagem(imgPB, dadosTela.imgLargura, dadosTela.imgAltura);
                fundoCinza.BackgroundImage = imgPBR;
            }
            else
            {
                fundoCinza.BackColor = Color.Gray;
            }

                //encaixes
                for (int i = 0; i < linhas; i++)
            {
                float y = i * alturaPeca;
                for (int j = 0; j < colunas; j++)
                {
                    encaixes.Add(new PointF(j * larguraPeca, y));
                }
            }

            foreach (var ponto in encaixes)
            {
                Panel marcador = new Panel();
                marcador.Size = new Size((int)larguraPeca, (int)alturaPeca);
                marcador.Location = new Point((int)ponto.X, (int)ponto.Y);
                marcador.BackColor = Color.Transparent;
                marcador.BorderStyle = BorderStyle.FixedSingle;
                marcador.ForeColor = Color.Cyan;
                pontoTela = fundoCinza.PointToScreen(Point.Round(ponto));
                this.pontoForm = this.PointToScreen(pontoTela);

                fundoCinza.Controls.Add(marcador);
                marcador.BringToFront();


            }

            //arasto das peças

            Rectangle areaFundoCinza = new Rectangle(fundoCinza.Location, fundoCinza.Size);

            List<PictureBox> pecasControle = new List<PictureBox>();

            Random rnd = new Random();

            for (int i = 0; i < pecas.Count; i++)
            {
                PictureBox peca = new PictureBox();
                peca.Image = pecas[i]; // sua lista de Bitmaps
                peca.Size = new Size((int)larguraPeca, (int)alturaPeca);
                peca.SizeMode = PictureBoxSizeMode.StretchImage; // para preencher o tamanho da peça

                Point posicaoAleatoria;
                Rectangle areaPeca;

                do
                {
                    posicaoAleatoria = new Point
                        (
                            rnd.Next(0, dadosTela.userLargura - peca.Width),
                            rnd.Next(0, dadosTela.userAltura - peca.Height)

                        );
                    areaPeca = new Rectangle(posicaoAleatoria, peca.Size);
                } while (areaFundoCinza.IntersectsWith(areaPeca));

                // Posição inicial aleatória fora do fundo cinza
                peca.Location = posicaoAleatoria;

                // Eventos de arrasto
                peca.MouseDown += Peca_MouseDown;
                peca.MouseMove += Peca_MouseMove;
                peca.MouseUp += Peca_MouseUp;

                this.Controls.Add(peca); // ou fundoCinza.Controls.Add(peca) se quiser que fiquem sobre o fundo
                pecasControle.Add(peca);
            }


        }

        


        private void Peca_MouseDown(object sender, MouseEventArgs e)
        {
            arrastando = true;
            pecaSelecionada = sender as PictureBox;
            offset = e.Location;
            pecaSelecionada.BringToFront();
        }

        private void Peca_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastando && pecaSelecionada != null)
            {
                Point posicaoMouse = PointToClient(Cursor.Position);
                this.SuspendLayout();
                pecaSelecionada.Left = posicaoMouse.X - offset.X;
                pecaSelecionada.Top = posicaoMouse.Y - offset.Y;
                this.ResumeLayout();
            }
        }

        private void Peca_MouseUp(object sender, MouseEventArgs e)
        {
            arrastando = false;
            EncaixarPeca();
            pecaSelecionada = null;
        }

        private void EncaixarPeca()
        {
            int margem = 10; // tolerância


            foreach (var ponto in encaixes)
            {
                Point pontoTela = fundoCinza.PointToScreen(Point.Round(ponto));
                Point pontoForm = this.PointToClient(pontoTela);

                if (Math.Abs(pecaSelecionada.Left - pontoForm.X) <= margem &&
                    Math.Abs(pecaSelecionada.Top - pontoForm.Y) <= margem)
                {
                    // Encaixa diretamente no ponto convertido
                    pecaSelecionada.Left = pontoForm.X;
                    pecaSelecionada.Top = pontoForm.Y;
                    break;
                }
            }
        }




        static (float larguraPeca, float alturaPeca, int colunas, int linhas) CalcularDimensoesPecas(String dificuldade, Bitmap img)
        {
            int linhas = 0, colunas = 0;

            switch (dificuldade.ToLower())
            {
                case "facil":
                    linhas = 6;
                    colunas = 8;
                    break;
                case "medio":
                    linhas = 9;
                    colunas = 12;
                    break;
                case "dificil":
                    linhas = 12;
                    colunas = 16;
                    break;
            }

            float largura = img.Width;
            float altura = img.Height;

            float larguraPeca = largura / colunas;
            float alturaPeca = altura / linhas;

            return (larguraPeca, alturaPeca, colunas, linhas);

        }


        public static List<Bitmap> separarImagemEmPecas(Bitmap img, float larguraPeca, float alturaPeca, int colunas, int linhas)
        {

            List<Bitmap> pecas = new List<Bitmap>();

            for (int i = 0; i < linhas; i++)
            {
                float y = i * alturaPeca;

                for (int j = 0; j < colunas; j++)
                {
                    RectangleF box = new RectangleF(
                        j * larguraPeca,
                        y,
                        larguraPeca,
                        alturaPeca
                    );

                    Bitmap peca = img.Clone(box, img.PixelFormat);
                    pecas.Add(peca);
                }
            }

            return pecas;

        }

    }
}

