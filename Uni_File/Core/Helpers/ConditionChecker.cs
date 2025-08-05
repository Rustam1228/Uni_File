using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using Uni_File.Core.Abstracts.IReader;
using Uni_File.Core.Reader;

namespace Uni_File.Core.Helpers
{
    public static class ConditionChecker
    {
        /// <summary>
        /// Проверяет наличие ключевых слов на страннице 
        /// </summary>
        /// <param name="isCheckAllKeyWords">Проверять наличие всех слов или достаточно хотя бы одного</param>
        /// <param name="isCheckRegister">Игнорировать регистр слова </param>
        /// <param name="textFile">Текст страницы</param>
        /// <param name="keyWords">Ключевые слова</param>
        /// <returns></returns>
        private static bool IsFilterCriteriaMet(bool isCheckAllKeyWords, bool isCheckRegister, 
            string textFile, params string[] keyWords)
        {
            if (isCheckAllKeyWords && isCheckRegister)
            {
                return keyWords.All(word => textFile.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            if (isCheckAllKeyWords && !isCheckRegister)
            {
                return keyWords.All(word => textFile.Contains(word));
            }
            if (!isCheckAllKeyWords && isCheckRegister)
            {
                return keyWords.Any(word => textFile.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            return keyWords.Any(word => textFile.Contains(word));

        }
        /// <summary>
        /// Проверяет отсканированный ли пдф файл
        /// </summary>
        /// <param name="path">полный путь к файлу</param>
        /// <returns></returns>
        public static bool IsCheekedPdfScanned(string path)
        {
            using (PdfReader newReader = new PdfReader(path))
            using (PdfDocument pdfDoc = new PdfDocument(newReader))
            {
                for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i += 3)
                {
                    string text = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i));
                    if (!string.IsNullOrWhiteSpace(text) && text.Trim().Length > 50)
                    {
                        return true;
                    }                    
                }
            }
            return false;
            
        }
        /// <summary>
        /// Выбирает нужную реализацию IPagedReader
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IPagedReader IsCheekedPdfReader(string path)
        {
            if (IsCheekedPdfScanned(path))
                return new PdfNotScannedReader();

            return new PdfScannedReader();

        }
        /// <summary>
        /// Показывает номера страниц удолетворяющие условию 
        /// </summary>
        /// <param name="isCheckAllKeyWords"></param>
        /// <param name="isCheckRegister"></param>
        /// <param name="path"></param>
        /// <param name="keyWords"></param>
        /// <returns></returns>        
        public static List<int> Filter(bool isCheckAllKeyWords, bool isCheckRegister, string path, params string[] keyWords)
        {
            IPagedReader reader = IsCheekedPdfReader(path);            
               
            var results = new List<int>();        
            
            var textDictionary = reader.ReadText(path);

            foreach (var item in textDictionary)
            {
                if (ConditionChecker.IsFilterCriteriaMet(isCheckAllKeyWords, isCheckRegister, item.Value, keyWords))
                {
                    results.Add(item.Key);
                }
            }
            return results;            
        }
        /// <summary>
        /// Проверяет тип файла
        /// </summary>
        /// <param name="path">Полный путь к файлу</param>
        /// <returns></returns>
        public static string IsCheekedTypeFile(string path)
        {
            string extension = Path.GetExtension(path).ToLower();

            if (extension == ".txt"|| extension == ".docx"|| extension == ".png"|| extension == ".pdf")
            {
                return extension;
            }
            return "Формат не поддерживается";

          
        }
        /// <summary>
        /// Выбирает нужную реализацию 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IFullReader IsCheekedTextReader(string type)
        {
            if (type== ".txt")                   
                return new TxtReader();

            if(type == ".docx")                 
                return new DocxReader();                          
                    
            return new ImageReader();
        }








    }
    
}
