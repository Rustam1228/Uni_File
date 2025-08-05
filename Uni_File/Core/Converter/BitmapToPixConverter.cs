using Tesseract;
using Uni_File.Core.Abstracts.IConverter;

namespace Uni_File.Core.Converter
{
    internal class BitmapToPixConverter : IBitmapToPixConverter
    {
        public Pix Convert(Bitmap bitmap)
        {
            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return Pix.LoadFromMemory(ms.ToArray());
            }
        }       
    }
}
