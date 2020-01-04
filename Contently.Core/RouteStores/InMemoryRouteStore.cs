using Contently.Core.Data.Interfaces;
using Contently.Core.Domain;
using Contently.Core.Domain.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contently.Core.RouteStores
{
    public class InMemoryRouteStore : IRouteStore
    {
        public InMemoryRouteStore(IContentDataService<RoutablePage> dataStore)
        {
            var pages = dataStore.GetAll();
            Build(pages);
        }

        public ConcurrentDictionary<string, Guid> RouteTable { get; private set; }

        public void AddOrUpdateRouteTable(PageRoute route)
        {
            RouteTable.AddOrUpdate(route.FullyQualifiedName, route.PageId, (key, oldValue) => route.PageId);
        }

        public void Build(IEnumerable<IRoutablePage> pages)
        {
            foreach(var page in pages)
            {
                foreach (var s in page.Sites) {
                    AddOrUpdateRouteTable(new PageRoute(s));
                }

                Build(page.ChildPages);
                
            }
        }

        public Guid? GetPageForRequest(string slug, string domain)
        {
            return RouteTable.GetValueOrDefault(string.Concat(domain, slug));
        }
    }
}
