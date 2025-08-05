using Xceed.Words.NET;
using Uni_File.Core.Abstracts.IReader;
using System.Text;


namespace Uni_File.Core.Reader
{
    internal class DocxReader : IFullReader
    {
        public string ReadText(string path)
        {
            var result = new StringBuilder();

            using (var document = DocX.Load(path))
            {
                result.AppendLine( document.Text);
            }
            return result.ToString();
        }
    }       
    
}

