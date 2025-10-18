using System.Drawing;
using System.Drawing.Imaging;

namespace puzzle.utils
{
    public static class imagemUtils
    {
        public static Bitmap redimensionarImagem(System.Drawing.Image img, int novaLargura, int novaAltura)
        {
            Bitmap imagemRedimensionada = new Bitmap(novaLargura, novaAltura);
            using (Graphics g = Graphics.FromImage(imagemRedimensionada))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, novaLargura, novaAltura);
            }
            return imagemRedimensionada;
        }

        public static Bitmap ConverterImagemParaPretoEBranco(Image pathImagem)
        {
            Bitmap original = new Bitmap(pathImagem);

            //cria imagem vaiza
            Bitmap pretoBranco = new Bitmap(original.Width, original.Height, original.PixelFormat);

            Rectangle rect = new Rectangle(0, 0, original.Width, original.Height);

            //da lock nos pixels na memoria
            BitmapData originalData = original.LockBits(rect, ImageLockMode.ReadOnly, original.PixelFormat);
            BitmapData pbData = pretoBranco.LockBits(rect, ImageLockMode.WriteOnly, pretoBranco.PixelFormat);

            //descobre a quantidade de bytes por pixel
            int bytesPorPixel = Image.GetPixelFormatSize(original.PixelFormat) / 8;
            int altura = original.Height;
            int largura = original.Width;
            int stride = originalData.Stride;

            //precisa ser não seguro pra mexer direto nos bytes da imagem
            unsafe
            {
                byte* ptrOriginal = (byte*)originalData.Scan0;
                byte* ptrPB = (byte*)pbData.Scan0;

                //percorre pixel por pixel
                for (int y = 0; y < altura; y++)
                {
                    for (int x = 0; x < largura; x++)
                    {
                        int index = y * stride + x * bytesPorPixel;

                        //ler a cor original
                        byte b = ptrOriginal[index];
                        byte g = ptrOriginal[index + 1];
                        byte r = ptrOriginal[index + 2];

                        //calcula o tom de cinza necessario pro pixel
                        byte cinza = (byte)(r * 0.3 + g * 0.59 + b * 0.11);

                        //salva a cor
                        ptrPB[index] = cinza;         // B
                        ptrPB[index + 1] = cinza;     // G
                        ptrPB[index + 2] = cinza;     // R

                        //mantem a transparencia original
                        if (bytesPorPixel == 4)
                            ptrPB[index + 3] = ptrOriginal[index + 3]; // Alpha
                    }
                }
            }
            //destrava a imagem
            original.UnlockBits(originalData);
            pretoBranco.UnlockBits(pbData);

            return pretoBranco;
        }


    }
}
