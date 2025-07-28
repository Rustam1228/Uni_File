
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using Uni_File.Core.Abstracts.IFilter;
using Uni_File.Core.Files_PDF.Filter;

namespace Uni_File.Core.Files_PDF
{
    public static class ConditionChecker
    {
        public static bool IsFilterCriteriaMet(bool isCheckAllKeyWords, bool isCheckRegister, 
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
        public static IFilter IsPdfScanned(string pathPdf)
        {
            using (PdfReader reader = new PdfReader(pathPdf))
            using (PdfDocument pdfDoc = new PdfDocument(reader))
            {
                for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i+=3)
                {
                    string text = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i));
                    if (!string.IsNullOrWhiteSpace(text) && text.Trim().Length > 50)
                    {
                        return new FilterPdfNotScanned();
                    }
                }
            }            
            return new FilterPdfScanned();
        }
    }
    
}
