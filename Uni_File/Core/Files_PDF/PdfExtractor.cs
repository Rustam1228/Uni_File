using iText.Kernel.Pdf;
using Uni_File.Core.Abstracts.IExtractor;
using Uni_File.Core.Abstracts.IFilter;


namespace Uni_File.Core.Files_PDF
{
    internal class PdfExtractor:IExtractor        
    {
        public void Extract(string pathInput, string pathOutput, bool isCheckAllKeyWords,
            bool isCheckRegister, params string[] keyWords)
        {
            IFilter filter = new FilterPdf();
            List <int> pageCoins = filter.Filter( isCheckAllKeyWords, isCheckRegister,pathInput, keyWords);

            using (PdfDocument pdfDoc = new PdfDocument(new PdfReader(pathInput)))
            {
                for (int i = 0; i < pageCoins.Count; i++)
                {
                    string newPathName = Guid.NewGuid().ToString();
                    string outputPdfPath = Path.Combine(pathOutput, $"Страница_{pageCoins[i]-1}_{newPathName}.pdf");
                    using (PdfDocument newPdfDoc = new PdfDocument(new PdfWriter(outputPdfPath)))
                    {                        
                        pdfDoc.CopyPagesTo(pageCoins[i], pageCoins[i], newPdfDoc);
                    }

                }
            }
        }
        
    }
}

