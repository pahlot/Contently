using Contently.Core.Data.Interfaces;
using Contently.Core.Domain;
using Contently.Core.Domain.ContentTypes.Simple;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contently.Data.Dapper
{
    public class MockPageRepository : IContentDataService<RoutablePage>
    {
        public IEnumerable<RoutablePage> GetAll()
        {
            return new[]
            {
                new RoutablePage(){ Name ="test 1", Slug = "test1", Content = new SimpleContent(){ Body = "This is test page 1" }, IsPublished = true, Id = Guid.Parse("f51007ee-923d-42d7-822b-335df109ce38")},
                new RoutablePage(){ Name ="test 2", Slug = "test2", Content = new SimpleContentWithImageListView(){ Body = "This is a listview",
                List = new []{ 
                    new SimpleContentWithImage(){ Body ="List item 1", Intro = "Intro for 1", Id = Guid.NewGuid()},
                    new SimpleContentWithImage(){ Body ="List item 2", Intro = "Intro for 2", Id = Guid.NewGuid()},
                    new SimpleContentWithImage(){ Body ="List item 3", Intro = "Intro for 3", Id = Guid.NewGuid()},
                    new SimpleContentWithImage(){ Body ="List item 4", Intro = "Intro for 4", Id = Guid.NewGuid()},
                } }, IsPublished = true, Id = Guid.Parse("f61007ff-923d-42d7-822b-335df109ce38")},
                new RoutablePage(){ Name ="test 3", Slug = "test3", Content = new SimpleContent(){ Body = "DRAFT This is test page 3" },  IsPublished = false, Id = Guid.Parse("f71007dd-923d-42d7-822b-335df109ce38")},
                new RoutablePage(){ Name ="test 4", Slug = "test1/test", Content = new SimpleContent(){ Body =  "This is test SUB page of page 1" }, IsPublished = true, Id = Guid.Parse("f99007aa-923d-42d7-822b-335df109ce38")}
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

        public IEnumerable<MenuItem> GetMenu()
        {
            return GetAll()
                .Where(x=> x.IsPublished)
                .Select(m => new MenuItem()
            {
                Name = m.Name,
                Path = m.Slug
            });
        }
    }
}
