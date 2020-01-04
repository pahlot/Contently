using Contently.Core.Domain;
using Contently.Core.Domain.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contently.Core.Data.Interfaces
{
    /// <summary>
    /// Represents a way to persist routes. This could be in-memory or in another storage mechanism
    /// </summary>
    public interface IRouteStore
    {
        /// <summary>
        /// Contains the routes.
        /// The Key is the url slug PLUS the domain.
        /// i.e. If we have two domains (test.com, tester.net) and a page with the slug /info we would have two instances the route table.
        ///             test.com/info
        ///             tester.net/info
        /// </summary>
        ConcurrentDictionary<string, Guid> RouteTable { get; }

        void AddOrUpdateRouteTable(PageRoute route);

        /// <summary>
        /// This does the heavy lifting for each request.
        /// </summary>
        /// <param name="slug"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        Guid? GetPageForRequest(string slug, string domain);

        void Build(IEnumerable<IRoutablePage> pages);
    }
}
