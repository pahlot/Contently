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
            var home = new RoutablePage() { Name = "Home", Slug = "/", Content = new SimpleContent() { Body = "This is the home page! Hello World!" }, IsPublished = true, IsRootPage =true, Id = Guid.Parse("f51007ee-923d-42d7-833b-335df109ce38") };
            var root1 = new RoutablePage() { Name = "test 1", Slug = "/test1", Content = new SimpleContent() { Body = "This is test page 1" }, IsPublished = true, Id = Guid.Parse("f51007ee-923d-42d7-822b-335df109ce38") };
            var root2 = new RoutablePage()
            {
                Name = "test 2",
                Slug = "/test2",
                Content = new SimpleContentWithImageListView()
                {
                    Body = "This is a listview",
                    List = new[]{
                    new SimpleContentWithImage(){ Body ="List item 1", Intro = "Intro for 1", Id = Guid.NewGuid()},
                    new SimpleContentWithImage(){ Body ="List item 2", Intro = "Intro for 2", Id = Guid.NewGuid()},
                    new SimpleContentWithImage(){ Body ="List item 3", Intro = "Intro for 3", Id = Guid.NewGuid()},
                    new SimpleContentWithImage(){ Body ="List item 4", Intro = "Intro for 4", Id = Guid.NewGuid()},
                }
                },
                IsPublished = true,
                Id = Guid.Parse("f61007ff-923d-42d7-822b-335df109ce38")
            };
            var root3 = new RoutablePage() { Name = "test 3", Slug = "/test3", Content = new SimpleContent() { Body = "DRAFT This is test page 3" }, IsPublished = false, Id = Guid.Parse("f71007dd-923d-42d7-822b-335df109ce38") };
            var root2Child = new RoutablePage() { Name = "test 4", Slug = "/test1/test", ParentPage = root2, Content = new SimpleContent() { Body = "This is test SUB page of page 1" }, IsPublished = true, Id = Guid.Parse("f99007aa-923d-42d7-822b-335df109ce38") };

            root2.ChildPages.Add(root2Child);

            home.ChildPages.Add(root1);
            home.ChildPages.Add(root2);
            home.ChildPages.Add(root3);


            return new[]
            {
               home,
               root1,
               root2,
               root3
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
            var all = GetAll().Where(x => x.IsPublished);
            var menu = all.Where(x => x.IsRootPage)
                .Select(m => new MenuItem() // Home
                {
                    Name = m.Name,
                    Path = m.Slug
                })
                .Union(all.Where(x => !x.IsRootPage)
                    .Select(m => new MenuItem()
                    {
                        Name = m.Name,
                        Path = m.Slug,
                        ChildMenuItems = m.ChildPages.Select(c => new MenuItem()
                        {
                            Name = c.Name,
                            Path = c.Slug
                        })
                    }));

            return menu;
        }
    }
}
