using iText.Kernel.Pdf;
using Uni_File.Core.Abstracts.IFilter;
using Uni_File.Core.Abstracts.ISlitter;

namespace Uni_File.Core.Files_PDF
{
    internal class PdfSlitter : ISlitter
    {
        public void Slitter(string pathInput, string pathOutput, bool isCheckAllKeyWords, 
            bool isCheckRegister, params string[] keyWords)
        {
            IFilter filter = new FilterPdf();
            List<int> pageCoins = filter.Filter(isCheckAllKeyWords, isCheckRegister, pathInput, keyWords);

            using (PdfDocument pdfDoc = new PdfDocument(new PdfReader(pathInput)))
            {
                int pdfDocCoins = pdfDoc.GetNumberOfPages();
                for (int i = 0; i < pageCoins.Count; i++)
                {
                    if(pdfDocCoins >= pageCoins[i])
                    {
                        string newPathName = Guid.NewGuid().ToString();
                        string outputPdfPath = Path.Combine(pathOutput, $"Копия_{i + 1}_{newPathName}.pdf");
                        if (i == 0 && pageCoins[i] == 1)
                        {
                            using (PdfDocument newPdfDoc = new PdfDocument(new PdfWriter(outputPdfPath)))
                            {
                                pdfDoc.CopyPagesTo(pageCoins[i], pageCoins[i+1]-1, newPdfDoc);
                            }
                        }
                        else if (i == 0 && pageCoins[i] > 1)
                        {
                            using (PdfDocument newPdfDoc = new PdfDocument(new PdfWriter(outputPdfPath)))
                            {
                                pdfDoc.CopyPagesTo(1, pageCoins[i]-1, newPdfDoc);
                            }
                            string outputPdfPath1 = Path.Combine(pathOutput, $"Копия_0{i + 1}{newPathName}.pdf");
                            using (PdfDocument newPdfDoc = new PdfDocument(new PdfWriter(outputPdfPath1)))
                            {
                                pdfDoc.CopyPagesTo(pageCoins[i], pageCoins[i + 1] - 1, newPdfDoc);
                            }
                        }
                        else if (i == pageCoins.Count - 1)
                        {
                            if (pageCoins[i]< pdfDocCoins)
                            {
                                using (PdfDocument newPdfDoc = new PdfDocument(new PdfWriter(outputPdfPath)))
                                {
                                    pdfDoc.CopyPagesTo(pageCoins[i], pdfDocCoins, newPdfDoc);
                                }
                            }
                            else
                            {
                                using (PdfDocument newPdfDoc = new PdfDocument(new PdfWriter(outputPdfPath)))
                                {
                                    pdfDoc.CopyPagesTo(pdfDocCoins, pdfDocCoins, newPdfDoc);
                                }
                            }
                            
                        }
                        else
                        {
                            using (PdfDocument newPdfDoc = new PdfDocument(new PdfWriter(outputPdfPath)))
                            {
                                pdfDoc.CopyPagesTo(pageCoins[i], pageCoins[i+1]-1, newPdfDoc);
                            }
                        }
                    }                   

                }
            }
        }        

    }
}
