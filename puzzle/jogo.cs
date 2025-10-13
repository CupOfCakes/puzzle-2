using puzzle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace puzzle
{
    public partial class jogo : Form
    {
        private dadosJogo dados;
        private bool arrastando = false;
        private PictureBox pecaAtual = null;
        private Point offset;
        List<PointF> encaixes = new List<PointF>();
        Point pontoTela;
        Point pontoForm;
        private Panel fundoCinza;


        public jogo(dadosJogo dados)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;

            dados = dados;

            tela dadosTela = new tela(dados.imgPath);

            var (larguraPeca, alturaPeca, colunas, linhas) = larguraPeca_alturaPeca_colunas_linhas(dados.dificuldade, dadosTela.image);

            List<Bitmap> pecas = separarPecas(dadosTela.image, larguraPeca, alturaPeca, colunas, linhas);

            
            //fundo cinza
            fundoCinza = new Panel();
            
            fundoCinza.Size = new System.Drawing.Size(dadosTela.imgLargura, dadosTela.imgAltura);
            fundoCinza.BackColor = System.Drawing.Color.Gray;

            this.Controls.Add(fundoCinza);

            int centroX = (this.ClientSize.Width - fundoCinza.Width) / 2;
            int centroY = (this.ClientSize.Height - fundoCinza.Height) / 2;

            fundoCinza.Anchor = AnchorStyles.None;
            fundoCinza.Location = new System.Drawing.Point(centroX, centroY);

            if (dados.imgAjuda)
            {
                Bitmap imgPB = ConverterImagemParaPretoEBranco(System.Drawing.Image.FromFile(dados.imgPath));
                fundoCinza.BackgroundImage = imgPB;
            }

            //encaixes
            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    encaixes.Add(new PointF(j * larguraPeca, i * alturaPeca));
                }
            }

            foreach (var ponto in encaixes)
            {
                Panel marcador = new Panel();
                marcador.Size = new Size((int)larguraPeca, (int)alturaPeca);
                marcador.Location = new Point((int)ponto.X, (int)ponto.Y);
                marcador.BackColor = System.Drawing.Color.Transparent;
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

        public static Bitmap ConverterImagemParaPretoEBranco(System.Drawing.Image original)
        {
            Bitmap pretoBranco = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color corOriginal = ((Bitmap)original).GetPixel(x, y);

                    // Calcula o tom de cinza (média ponderada)
                    int cinza = (int)(corOriginal.R * 0.3 + corOriginal.G * 0.59 + corOriginal.B * 0.11);

                    Color corCinza = Color.FromArgb(cinza, cinza, cinza);
                    pretoBranco.SetPixel(x, y, corCinza);
                }
            }

            return pretoBranco;
        }


        private void Peca_MouseDown(object sender, MouseEventArgs e)
        {
            arrastando = true;
            pecaAtual = sender as PictureBox;
            offset = e.Location;
            pecaAtual.BringToFront();
        }

        private void Peca_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastando && pecaAtual != null)
            {
                Point posicaoMouse = PointToClient(Cursor.Position);
                pecaAtual.Left = posicaoMouse.X - offset.X;
                pecaAtual.Top = posicaoMouse.Y - offset.Y;
            }
        }

        private void Peca_MouseUp(object sender, MouseEventArgs e)
        {
            arrastando = false;
            EncaixarPeca();
            pecaAtual = null;
        }

        private void EncaixarPeca()
        {
            int margem = 10; // tolerância

            foreach (var ponto in encaixes)
            {
                // Converte o ponto de encaixe para coordenadas do formulário
                Point pontoTela = fundoCinza.PointToScreen(Point.Round(ponto));
                Point pontoForm = this.PointToClient(pontoTela);

                if (Math.Abs(pecaAtual.Left - pontoForm.X) <= margem &&
                    Math.Abs(pecaAtual.Top - pontoForm.Y) <= margem)
                {
                    pecaAtual.Left = pontoForm.X;
                    pecaAtual.Top = pontoForm.Y;
                    break; // encaixou, não precisa continuar
                }
            }
        }




        static (float larguraPeca, float alturaPeca, int colunas, int linhas) larguraPeca_alturaPeca_colunas_linhas(String dificuldade, Bitmap img)
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

    
    public static List<Bitmap> separarPecas(Bitmap img, float larguraPeca, float alturaPeca, int colunas, int linhas)
        {
  
            List<Bitmap> pecas = new List<Bitmap>();

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    RectangleF box = new RectangleF(
                        j * larguraPeca,
                        i * alturaPeca,
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
