using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using Uni_File.Core.Abstracts.IReader;

namespace Uni_File.Core.Reader
{
    public class PdfNotScannedReader : IPagedReader
    {
        public Dictionary<int, string> ReadText(string path)
        {
            Dictionary<int,string> result = new Dictionary<int,string>();
            using (PdfReader reader = new PdfReader(path))
            using (PdfDocument pdfDoc = new PdfDocument(reader))
            {
                for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                {
                    result.Add(i, PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i)));
                }
            }
            return result;
        }
    }
}
