using Contently.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Contently.Core.DiscoveryServices
{
    public class ContentTypeDiscoveryService : IContentTypeDiscoryService
    {
        private IEnumerable<string> contentTypes;

        public IEnumerable<string> Discover()
        {
            if(contentTypes == null)
            {
                contentTypes =
                      Assembly.GetExecutingAssembly()
                          .GetReferencedAssemblies()
                          .SelectMany(name => Assembly.Load(name).GetTypes())
                          .Union(AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()))
                          .Where(t => t.GetInterfaces().Any(i => i == typeof(IContentItem)))
                          .Select(t => t.FullName);
            }
            return contentTypes;
        }
    }
}
