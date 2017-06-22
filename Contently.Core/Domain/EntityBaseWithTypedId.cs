using System;

namespace Contently.Core.Domain
{
    public class EntityBaseWithTypedId<T>
    {
        public T Id { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

    }
}