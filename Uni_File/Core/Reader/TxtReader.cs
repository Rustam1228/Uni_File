using System.Text;
using Uni_File.Core.Abstracts.IReader;

namespace Uni_File.Core.Reader
{
    public class TxtReader : IFullReader
    {
        public string ReadText(string path)
        {
            var result = new StringBuilder();

            using (var reader = new StreamReader(path))
            {
                result.AppendLine( reader.ReadToEnd());               
            }
            return result.ToString();
        }
    }
}
