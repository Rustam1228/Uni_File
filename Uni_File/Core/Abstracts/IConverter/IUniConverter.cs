
namespace Uni_File.Core.Abstracts.IConverter
{
    
    public interface IUniConverter<TInput, TOutput>
    {
        TOutput Convert(TInput inputFile);
    }
}
