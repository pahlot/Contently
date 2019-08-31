namespace Contently.Core.Domain.Interfaces
{
    /// <summary>
    /// Content items 
    /// </summary>
    public interface IContentItem
    {
        string Controller { get; }
       IContentTemplate Template { get; }
    }
}
