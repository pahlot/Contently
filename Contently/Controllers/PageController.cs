using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contently.Core.Data.Interfaces;
using Contently.Core.Domain;

namespace Contently.Controllers
{
    public class PageController : Controller
    {
        //public IActionResult Index(string slug, string template = null)
        //{
        //    return View();
        //}

        protected IContentDataService<RoutablePage> dataService;

        public PageController(IContentDataService<RoutablePage> ds)
        {
            dataService = ds;
        }

        public IActionResult Index(string id)
        {
            var page = dataService.GetOne(Guid.Parse(id));
            return View(page);
        }

       // [Route("{id}/draft")]
       // TODO: Add [Authorize]
        public IActionResult Draft(string id)
        {
            var page = dataService.GetOne(Guid.Parse(id));
            return View("Index", page);
        }


    }
}