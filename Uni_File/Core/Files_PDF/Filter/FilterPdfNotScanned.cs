using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using Uni_File.Core.Abstracts.IFilter;

namespace Uni_File.Core.Files_PDF.Filter
{
    public class FilterPdfNotScanned : IFilter
    {
        public List<int> Filter(bool isCheckAllKeyWords, bool isCheckRegister, string path, params string[] keyWords)
        {
            var Results = new List<int>();
            using (PdfReader reader = new PdfReader(path))
            using (PdfDocument pdfDoc = new PdfDocument(reader))
            {
                for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i ++)
                {
                    string text = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i));
                    if (ConditionChecker.IsFilterCriteriaMet(isCheckAllKeyWords, isCheckRegister, text, keyWords))
                    {
                        Results.Add(i);
                    }
                }
            }
            return Results;
        }
    }
}
