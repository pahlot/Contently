using System;
using System.Collections.Generic;
using System.Text;

namespace Contently.Core.Domain.Interfaces
{
    public interface IRoutablePage
    {
        #region Route specific fields

        /// <summary>
        /// The area all the views and controllers live
        /// </summary>
        string AreaName { get; }

        /// <summary>
        /// The name of the controller which will handle calls and content delivery
        /// </summary>
        string RoutingController { get; }
        
        #endregion
        string Name { get; set; }
        string Slug { get; set; }

        string SeoTitle { get; set; }
        string MetaTitle { get; set; }
        string MetaKeywords { get; set; }
        string MetaDescription { get; set; }

        string Title { get; set; }
        string Intro { get; set; }
        IContentItem Content { get; set; }
        
        bool IsPublished { get; set; }
        DateTime PublishDate { get; set; }
        DateTime UnPublishDate { get; set; }
    }
}
