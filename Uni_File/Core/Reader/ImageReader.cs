using System.Text;
using Tesseract;
using Uni_File.Core.Abstracts.IReader;

namespace Uni_File.Core.Reader
{
    public class ImageReader:IFullReader
    {
        public string ReadText(string path)
        {
            var result = new StringBuilder();

            string tesseractDataPath = Path.Combine(Directory.GetCurrentDirectory(), "tessdata");
            if (!Directory.Exists(tesseractDataPath))
            {
                throw new DirectoryNotFoundException($"Папка tessdata не найдена: {tesseractDataPath}");
            }

            using (var engine = new TesseractEngine(tesseractDataPath, "rus", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(path))
                {
                    using (var page = engine.Process(img))
                    {
                        result.AppendLine(page.GetText());
                    }
                }
            }
            return result.ToString();
        }

        
    }
}
