using Contently.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contently.Core.Data.Interfaces
{
    public interface ISiteDataService : IDataServiceWithTypedId<Site, Guid>
    {
        /// <summary>
        /// Returns the Guid and all the aliases for a given site
        /// </summary>
        /// <returns></returns>
        IDictionary<Guid, string[]> GetSites();

        void AddAlias(Guid siteId, string alias);
        void AddAliaes(Guid siteId, string[] alias, bool overwrite = false);
    }

    public interface IContentDataService<TEntity> : IDataServiceWithTypedId<TEntity, Guid> where TEntity : EntityBaseWithTypedId<Guid> {
      
        IEnumerable<MenuItem> GetMenuForSite(Guid siteId);
    }

    public interface IDataServiceWithTypedId<TEntity, TId> where TEntity : EntityBaseWithTypedId<TId>
    {
        IQueryable<TEntity> Query();

        IEnumerable<TEntity> GetAll();
        TEntity GetOne(TId id);

        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);

        TEntity FindOne(Func<TEntity, bool> predicate);

        TEntity AddOrUpdate(TEntity entity);

        bool Delete(TId id);

      
    }
}
