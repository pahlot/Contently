using Contently.Core.Data.Interfaces;
using Contently.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contently.Data.Dapper
{
    public class MockPageRepository : IDataService<RoutablePage>
    {
        public IEnumerable<RoutablePage> GetAll()
        {
            return new[]
            {
                new RoutablePage(){ Slug = "test1", Content = "This is test page 1", IsPublished = true, Id = Guid.Parse("f51007ee-923d-42d7-822b-335df109ce38")},
                new RoutablePage(){ Slug = "test2", Content = "This is test page 2", IsPublished = true, Id = Guid.Parse("f61007ff-923d-42d7-822b-335df109ce38")},
                new RoutablePage(){ Slug = "test3", Content = "DRAFT This is test page 3",  IsPublished = false, Id = Guid.Parse("f71007dd-923d-42d7-822b-335df109ce38")},
                new RoutablePage(){ Slug = "test1/test", Content = "This is test SUB page of page 1", Id = Guid.Parse("f99007aa-923d-42d7-822b-335df109ce38")}
            };
        }

        public RoutablePage GetOne(Guid id)
        {
            return GetAll().Where(x=> x.Id == id).FirstOrDefault();
        }

        public RoutablePage FindOne(Func<RoutablePage, bool> predicate)
        {
            return GetAll().Where(predicate).FirstOrDefault();
        }

        public IEnumerable<RoutablePage> Find(Func<RoutablePage, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
