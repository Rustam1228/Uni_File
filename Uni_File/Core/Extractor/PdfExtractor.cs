using iText.Kernel.Pdf;
using Uni_File.Core.Abstracts.IExtractor;
using Uni_File.Core.Helpers;


namespace Uni_File.Core.Extractor
{
    internal class PdfExtractor:IExtractor        
    {
        public void Extract(string pathInput, string pathOutput, bool isCheckAllKeyWords,
            bool isCheckRegister, params string[] keyWords)
        {
            
            List <int> pageCoins = ConditionChecker.Filter( isCheckAllKeyWords, isCheckRegister,pathInput, keyWords);

            using (PdfDocument pdfDoc = new PdfDocument(new PdfReader(pathInput)))
            {
                for (int i = 0; i < pageCoins.Count; i++)
                {
                    string newName = Guid.NewGuid().ToString();
                    string outputPdfPath = Path.Combine(pathOutput, $"Страница_{pageCoins[i]}_{newName}.pdf");
                    using (PdfDocument newPdfDoc = new PdfDocument(new PdfWriter(outputPdfPath)))
                    {                        
                        pdfDoc.CopyPagesTo(pageCoins[i], pageCoins[i], newPdfDoc);
                    }

                }
            }
            
        }
       
    }
}

