using Uni_File.Core.Abstracts.IReader;
using Uni_File.Core.Abstracts.IWrite;
using Uni_File.Core.Helpers;
using Uni_File.Core.Reader;

namespace Uni_File.Core.Write
{
    public class WriteTxt : IWrite
    {
        public string WriteText(string path, string pathOutput, string newName)
        {
            string newPath = Path.Combine(pathOutput, $"{newName}.txt");

            if (File.Exists(newPath))
            {
                return "Файл с таким именем существует";
            }

            string isCheekedTypeFile = ConditionChecker.IsCheekedTypeFile(path);

            if (isCheekedTypeFile== "Формат не поддерживается")
            {
                return isCheekedTypeFile;
            }

            if (isCheekedTypeFile == ".pdf")
            {     
                IPagedReader readers  = ConditionChecker.IsCheekedPdfReader(path);
                var pageText = readers.ReadText(path); 
                
                using (var fileStream = new FileStream(newPath, FileMode.Create, FileAccess.Write))                   
                using (var writer = new StreamWriter(fileStream))
                {
                    foreach (var item in pageText)
                    {
                        writer.WriteLine(item.Value);
                    }
                }               

                return "Pdf Файл записан";
            }

            IFullReader reader = ConditionChecker.IsCheekedTextReader(isCheekedTypeFile);
            string text = reader.ReadText(path);            
           
            using (var fileStream = new FileStream(newPath, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(fileStream))
            {
                writer.WriteLine(text);
            }
           
            return "Файл записан";
        }

       
    }
}
