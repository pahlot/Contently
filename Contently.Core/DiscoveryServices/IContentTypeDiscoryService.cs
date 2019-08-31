using System.Collections.Generic;

namespace Contently.Core.DiscoveryServices
{
    public interface IContentTypeDiscoveryService
    {
        IEnumerable<string> Discover();
    }
}