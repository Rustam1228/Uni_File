using PdfiumViewer;
using System.Drawing;
using System.Text;
using Tesseract;
using Uni_File.Core.Abstracts.IReader;

namespace Uni_File.Core.Files_PDF
{
    public class ImageTextReader : IImageTextReader
    {
        public string ReadText(Pix image)
        {
            string tessDataPath = Path.Combine(Directory.GetCurrentDirectory(), "tessdata");

            if (!Directory.Exists(tessDataPath))
            {
                throw new DirectoryNotFoundException($"Папка tessdata не найдена: {tessDataPath}");
            }

            using (var engine = new TesseractEngine(tessDataPath, "rus", EngineMode.Default))
            {
                using (var page = engine.Process(image))
                {
                    return page.GetText();
                }                
            }
        }
    }
}
