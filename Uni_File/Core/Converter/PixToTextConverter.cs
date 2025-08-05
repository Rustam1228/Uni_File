using Tesseract;
using Uni_File.Core.Abstracts.IConverter;
namespace Uni_File.Core.Converter
{
    public class PixToTextConverter : IPixToTextConverter
    {
        public string Convert(Pix inputFile)
        {
            string tessDataPath = Path.Combine(Directory.GetCurrentDirectory(), "tessdata");

            if (!Directory.Exists(tessDataPath))
            {
                throw new DirectoryNotFoundException($"Папка tessdata не найдена: {tessDataPath}");
            }

            using (var engine = new TesseractEngine(tessDataPath, "rus", EngineMode.Default))
            {
                using (var page = engine.Process(inputFile))
                {
                    return page.GetText();
                }
            }
        }
       
    }
}
