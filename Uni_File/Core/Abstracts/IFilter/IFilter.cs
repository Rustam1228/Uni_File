
namespace Uni_File.Core.Abstracts.IFilter
{
    internal interface IFilter
    {
        List< int> Filter(bool isCheckAllKeyWords, bool isCheckRegister, 
             string path, params string[] keyWords);
    }
}
