
namespace Uni_File.Core.Abstracts.IExtractor
{
    
    public interface IExtractor
    { 
        void Extract(string pathInput, string pathOutput, bool isCheckAllKeyWords,
            bool isCheckRegister, params string[] keyWords);
    }
}
