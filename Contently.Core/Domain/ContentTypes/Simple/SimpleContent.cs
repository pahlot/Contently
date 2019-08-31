using Contently.Core.Domain.Interfaces;

namespace Contently.Core.Domain.ContentTypes.Simple
{
    public class SimpleContent : EntityBase, IContentItem
    {
        public string Controller => "SimpleContent";

        public IContentTemplate Template { get; internal set; }
        public string Body { get; set; }
        public string Intro { get; set; }

        public SimpleContent()
        {
            Template = new ContentTemplate()
            {
                DisplayView = "SimpleContentView",
                EditView = "SimpleContentEditView"
            };
        }
    }
}
