namespace Uni_File.Core.Abstracts.IReader
{
    internal interface IDocumentReader<TInput, TOutput>
    {
        TOutput ReadText(TInput file);        
    }
}
