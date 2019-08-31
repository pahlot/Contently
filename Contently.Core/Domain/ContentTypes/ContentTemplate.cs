using Contently.Core.Domain.Interfaces;

namespace Contently.Core.Domain.ContentTypes
{
    public class ContentTemplate : IContentTemplate
    {
        public string DisplayView { get; set; }
        public string EditView { get; set; }
    }
}
