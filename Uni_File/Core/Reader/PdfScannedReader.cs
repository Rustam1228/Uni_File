using PdfiumViewer;
using Uni_File.Core.Abstracts.IConverter;
using Uni_File.Core.Abstracts.IReader;
using Uni_File.Core.Converter;

namespace Uni_File.Core.Reader
{
    public class PdfScannedReader : IPagedReader
    {               
        public Dictionary<int, string> ReadText(string path)
        {
            IBitmapToPixConverter convertBitmapToPix = new BitmapToPixConverter();
            IPixToTextConverter pixToTextConverter = new PixToTextConverter();
            Dictionary<int, string> result = new Dictionary<int, string>();           

            using (var document = PdfDocument.Load(path))
            {
                for (int i = 1; i <= document.PageCount; i++)
                {
                    using (var image = document.Render(i-1, 300, 300, PdfRenderFlags.LcdText))
                    using (var clonedImage = (Bitmap)image)
                    {
                        using (var pix = convertBitmapToPix.Convert(clonedImage))
                        {                            
                            result.Add(i, pixToTextConverter.Convert(pix));
                        }

                    }
                }
            }
            return result;
        }
    }
}
