using System;
using System.Collections.Generic;

namespace Contently.Core.Domain.Interfaces
{
    public interface IRoutablePage : IEntity
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

        bool IsRootPage { get; set; }

        IRoutablePage ParentPage { get; set; }

        IList<IRoutablePage> ChildPages { get; set; }

        int DisplayOrder { get; set; }

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

        IList<SitePage> Sites { get; set; }
    }
}
