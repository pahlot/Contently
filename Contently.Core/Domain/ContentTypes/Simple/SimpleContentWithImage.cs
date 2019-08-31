using System.Collections;

namespace Contently.Core.Domain.ContentTypes.Simple
{
    public class SimpleContentWithImage : SimpleContent
    {
        public string ImagePath { get; set; }

        public SimpleContentWithImage()
        {
            Template = new ContentTemplate()
            {
                DisplayView = "SimpleContentWithImageView",
                EditView = "SimpleContentWithImageEditView"
            };
        }
    }
}
