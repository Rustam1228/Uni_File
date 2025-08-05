
namespace Uni_File.Core.Abstracts.ISlitter{
    
    public interface ISlitter
    {        
        void Slitter (string pathInput, string pathOutput, bool isCheckAllKeyWords,
            bool isCheckRegister, params string[] keyWords);
    }
}
