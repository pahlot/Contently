using System;

namespace Contently.Core.Domain
{
    public interface IEntityBaseWithTypedId<T>
    {
        DateTime Created { get; set; }
        T Id { get; set; }
        DateTime Modified { get; set; }
    }
}