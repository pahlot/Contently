using System.Collections.Generic;

namespace Contently.Core.Domain
{
    public class Site : EntityBase
    {
        public string Name { get; set; }
        public string PrimaryDomain { get; set; }

        /// <summary>
        /// This is for any other aliases this site might have so we can route variants such as
        /// www.site.com
        /// site.com
        /// sub.site.com
        /// </summary>
        public string[] Aliases { get; set; }

        // TODO: Might not have to really do this if we use native MVC useHttps
        public bool UseHttps { get; set; } = true;

        public IList<SitePage> Pages { get; set; } = new List<SitePage>();
    }
}
