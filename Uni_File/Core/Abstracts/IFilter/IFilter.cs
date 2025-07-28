
namespace Uni_File.Core.Abstracts.IFilter
{
    public interface IFilter
    {
        List< int> Filter(bool isCheckAllKeyWords, bool isCheckRegister, 
             string path, params string[] keyWords);
    }
}
