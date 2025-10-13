using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static puzzle.FM_config;

namespace puzzle
{
    public partial class Galeria : Form
    {

        private String galeriaPasta = Path.Combine(
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")),
                "galeria");

        public Galeria()
        {
            InitializeComponent();
        }

        private void Galeria_Load(object sender, EventArgs e)
        {
            LB_Galeria.Text = $"Imagem selecionada: {Globals.fileName}";

            CarregarImagens();

        }


        private void CarregarImagens()
        {
            string[] imagens = Directory.GetFiles(galeriaPasta, "*.*")
                .Where(f => f.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                    || f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                    || f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                    || f.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase)
                    || f.EndsWith(".gif", StringComparison.OrdinalIgnoreCase)
                    || f.EndsWith(".jfif", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string imgPath in imagens)
            {
                // Cria a miniatura
                Image img = Image.FromFile(imgPath);
                Image thumb = new Bitmap(img, new Size(100, 100));

                // Botão com a imagem
                Button btn = new Button
                {
                    Width = 110,
                    Height = 110,
                    BackgroundImage = thumb,
                    BackgroundImageLayout = ImageLayout.Zoom,
                    Tag = imgPath // guarda o caminho da imagem
                };

                btn.Click += (s, e) => SelecionarImagem(imgPath);

                FLP_Galeria.Controls.Add(btn);
            }
        }

        private void SelecionarImagem(String imgPath)
        {
            Globals.filePath = imgPath;
            Globals.fileName = Path.GetFileName(imgPath);

            LB_Galeria.Text = $"Imagem selecionada: {Globals.fileName}";


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FLP_Galeria_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}

