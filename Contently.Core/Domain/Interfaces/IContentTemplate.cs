namespace Contently.Core.Domain.Interfaces
{
    public interface IContentTemplate
    {
        /// <summary>
        /// Path to the view that handles the display of the content
        /// </summary>
        string DisplayView { get; set; }

        /// <summary>
        /// Path to the view that handles editing the view
        /// </summary>
        string EditView { get; set; }
    }
}