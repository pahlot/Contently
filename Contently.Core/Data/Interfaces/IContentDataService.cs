using Contently.Core.Domain;
using System;
using System.Collections.Generic;

namespace Contently.Core.Data.Interfaces
{
    public interface IContentDataService<TEntity> : IDataServiceWithTypedId<TEntity, Guid> where TEntity : EntityBaseWithTypedId<Guid> { }

    public interface IDataServiceWithTypedId<TEntity, TId> where TEntity : EntityBaseWithTypedId<TId>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetOne(TId id);

        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        TEntity FindOne(Func<TEntity, bool> predicate);

        IEnumerable<MenuItem> GetMenu();
    }
}
