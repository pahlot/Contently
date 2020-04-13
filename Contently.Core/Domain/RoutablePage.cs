using Contently.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contently.Core.Domain
{
    public class RoutablePage : EntityBase, IRoutablePage
    { 
        public string AreaName => "";
        public string RoutingController => Content?.Controller;

        public bool IsRootPage { get; set; }

        public IRoutablePage ParentPage { get; set; }

        public IList<IRoutablePage> ChildPages { get; set; } = new List<IRoutablePage>();

        public int DisplayOrder { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string SeoTitle { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string Intro { get; set; }

        public bool IsPublished { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UnPublishDate { get; set; }
        public IContentItem Content { get; set; }

        /// <summary>
        /// Each page can be assigned to multiple sites
        /// </summary>
        public IList<SitePage> Sites { get; set; } = new List<SitePage>();

        public void AddToSite(Site site)
        {
            if (Sites.Where(x => x.SiteId == site.Id).Any())
                return;

            Sites.Add(new SitePage()
            {
                Page = this,
                PageId = Id,
                Site = site,
                SiteId = site.Id
            });

            foreach(var child in ChildPages)
            {
                child.AddToSite(site);
            }
        }
       
    }
}
