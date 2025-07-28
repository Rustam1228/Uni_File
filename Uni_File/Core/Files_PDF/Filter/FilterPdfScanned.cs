using PdfiumViewer;
using Uni_File.Core.Abstracts.IConverter;
using Uni_File.Core.Abstracts.IFilter;
using Uni_File.Core.Abstracts.IReader;

namespace Uni_File.Core.Files_PDF.Filter
{
    public class FilterPdfScanned : IFilter
    {
        public List <int> Filter(bool isCheckAllKeyWords, bool isCheckRegister, 
            string path, params string[] keyWords)
        {           
            var Results = new List<int>();
            IBitmapToPixConverter convertBitmapToPix = new BitmapToPixConverter();
            IImageTextReader imageReader = new ImageTextReader();
            
            using (var document = PdfDocument.Load(path))
            {
                for (int i = 0; i < document.PageCount; i++)
                {
                    using (var image = document.Render(i, 300, 300, PdfRenderFlags.LcdText))
                    using (var clonedImage = (Bitmap)image)
                    {
                        using (var pix = convertBitmapToPix.Convert(clonedImage))
                        {
                            string pageText = imageReader.ReadText(pix);
                            if (ConditionChecker.IsFilterCriteriaMet(isCheckAllKeyWords, isCheckRegister, pageText, keyWords))
                            {
                                Results.Add(i + 1);
                            }

                        }

                    }
                }
            }
            return Results;
        }     
        
    }
}
