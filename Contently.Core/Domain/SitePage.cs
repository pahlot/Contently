using System;

namespace Contently.Core.Domain
{
    public class SitePage 
    {
        public Site Site { get; set; }
        public Guid SiteId { get; set; }

        public RoutablePage Page { get; set; }
        public Guid PageId { get; set; }
    }
}