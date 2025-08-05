
namespace Uni_File.Core.Abstracts.IReader
{
    public interface IUniReader <TInput, TOutput>
    {
        TOutput ReadText (TInput path);
    }
}
