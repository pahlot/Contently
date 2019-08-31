using System.Collections.Generic;

namespace Contently.Core.Domain.ContentTypes.Simple
{
    /// <summary>
    /// Represents a view that has a list of other SimpleContentWithImage classes
    /// A great example would be a blog or article list
    /// </summary>
    public class SimpleContentWithImageListView : SimpleContentWithImage
    {
        public IEnumerable<SimpleContentWithImage> List { get; set; }

        public SimpleContentWithImageListView()
        {
            Template = new ContentTemplate()
            {
                DisplayView = "SimpleContentWithImageListView",
                EditView = "SimpleContentWithImageListEditView"
            };
        }
    }
}
