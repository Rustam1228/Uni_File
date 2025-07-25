using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesseract;
using Uni_File.Core.Abstracts.IReader;

namespace Uni_File.Core.Image
{
    public class ImageToText : IFilePathTextReader
    {
        public string ReadText(string path)
        {
            var newText = new StringBuilder();
            string tesseractDataPath = Path.Combine(Directory.GetCurrentDirectory(), "tessdata");
            using (var engine = new TesseractEngine(tesseractDataPath, "rus", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(path))
                {
                    using (var page = engine.Process(img))
                    {
                        newText.AppendLine(page.GetText());
                    }
                }
            }
            return newText.ToString();
        }

    }
}
