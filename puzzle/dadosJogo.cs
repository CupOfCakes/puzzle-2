using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puzzle
{
    public class dadosJogo
    {
        public string dificuldade { get; set; }
        public string imgPath { get; set; }
        public bool imgAjuda { get; set; }
    }

    public class tela 
    { 
        public int userAltura { get; set; }
        public int userLargura { get; set; }
        public int imgLargura { get; set; }
        public int imgAltura { get; set; }
        public int maxLargura { get; set; }
        public int maxAltura { get; set; }
        public Bitmap image { get; set; }



        public tela(String path)
        {
            //tela do pc do user
            userAltura = Screen.PrimaryScreen.Bounds.Height;
            userLargura = Screen.PrimaryScreen.Bounds.Width;

            //maximo de tamanho da imagem
            maxAltura = (int)(userAltura * 0.6);
            maxLargura = (int)(userLargura * 0.6);

            //dados da imagem
            using (Bitmap imagem = new Bitmap(path))
            {
                //dimensões da imagem
                double proporcao = (double)imagem.Width / imagem.Height;

                imgLargura = maxLargura;
                imgAltura = (int)(imgLargura / proporcao);



                if (imgAltura > maxAltura)
                {
                    imgAltura = maxAltura;
                    imgLargura = (int)Math.Round(imgAltura * proporcao);
                }

                //redimensionar imagem

                Bitmap novaImg = new Bitmap(imgLargura, imgAltura);

                using (Graphics g = Graphics.FromImage(novaImg)) { 
                    
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    g.DrawImage(imagem, 0, 0, imgLargura, imgAltura);

                }

                image = novaImg;


            }   

        }
    }
}
