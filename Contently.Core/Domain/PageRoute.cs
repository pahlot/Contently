using System;

namespace Contently.Core.Domain
{
    /// <summary>
    /// This is a model which represents a route for a page
    /// </summary>
    public class PageRoute : EntityBase
    {
        public PageRoute() { }

        public PageRoute(SitePage sitePage)
        {
            Domain = sitePage.Site.Domain;
            Slug = sitePage.Page.Slug;
        }

        /// <summary>
        /// The domain name.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Url Slug
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Id of the page so we can avoid string based lookups
        /// </summary>
        public Guid PageId { get; set; }

        public string FullyQualifiedName => string.Concat(Domain, Slug);

        ///// <summary>
        ///// If this is a 301 Permanent Redirect
        ///// TODO: Implement the logic to grab the most recent Route for this page and domain
        ///// </summary>
        //public bool IsPermanentRedirect { get; set; }
    }
}
