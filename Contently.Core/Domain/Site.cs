using System;
using System.Collections.Generic;
using System.Text;

namespace Contently.Core.Domain
{
    public class Site : EntityBase
    {
        public string Name { get; set; }
        public string Domain { get; set; }

        // TODO: Might not have to really do this if we use native MVC useHttps
        public bool UseHttps { get; set; } = true;

        public IList<SitePage> Pages { get; set; } = new List<SitePage>();
    }
}
