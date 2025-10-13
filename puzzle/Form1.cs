using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puzzle;


namespace puzzle
{
    public partial class FM_config : Form
    {

        public FM_config()
        {
            InitializeComponent();
            
        }

        public static class Globals
        {
            public static string filePath { get; set; } = "";
            public static string fileName { get; set; } = "Nenhuma";
            public static string pastaGaleria { get; set; } = Path.Combine(
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")),
                "galeria");


        }


        private void centralizar(Control ctrl) 
        {
            ctrl.Left = (this.ClientSize.Width - ctrl.Width) / 2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            centralizar(GB_dificuldade);
            centralizar(GB_imagem);
            centralizar(GB_adicional);
            centralizar(BT_pronto);

            //LB_imgSelecionada.Text = $"Imagem selecionada: {Globals.fileName}";
        }

        class dados
        {
            public string dificuldade;
            public string imgPath;
            public bool imgAjuda;
            public bool save;
            
        }

        private void BT_selecionar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                ofd.Filter = "Imagens|*.png;*.jpg;*.jpeg;*.bmp;*.jfif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Globals.filePath = ofd.FileName;

                    Globals.fileName = Path.GetFileName(Globals.filePath);


                    LB_imgSelecionada.Text = $"Imagem selecionada: {Globals.fileName}";

                }
            }

        }

        private void BT_galeria_Click(object sender, EventArgs e)
        {
            // Crie uma instância do Form2 (o formulário a ser aberto)
            Galeria novoForm = new Galeria();

            novoForm.ShowDialog();

            LB_imgSelecionada.Text = $"Imagem selecionada: {Globals.fileName}";
        }

        private void BT_pronto_Click(object sender, EventArgs e)
        {

            if(Globals.fileName == "Nenhuma")
            {
                MessageBox.Show("Nenhuma imagem selecionada! Selecione uma");
                return;
            }
            else if (!File.Exists(Globals.filePath))
            {
                MessageBox.Show("Arquivo não encontrado! Tente novamente");
                return;
            }

            // Primeiro pega o RadioButton selecionado
            var radioSelecionado = GB_dificuldade.Controls
                .OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);



            // Cria o objeto com os dados
            var dados = new dadosJogo
            {
                dificuldade = radioSelecionado.Text,
                imgPath = Globals.filePath,
                imgAjuda = CB_imgAJuda.Checked,
            };

            if (CB_imgSave.Checked)
            {
                salvarImgGaleria();
            }

            var formJogo = new jogo(dados);
            formJogo.Show();

        }

        private void salvarImgGaleria()
        {
            if (!Directory.Exists(Globals.pastaGaleria))
            {
                Directory.CreateDirectory(Globals.pastaGaleria);
            }

            String caminhoDestino = Path.Combine(Globals.pastaGaleria, Globals.fileName);


            if (File.Exists(caminhoDestino))
            {
                MessageBox.Show("Imagem já existe nessa pasta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                File.Copy(Globals.filePath, caminhoDestino);
                MessageBox.Show("Imagem salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

    }
}
