using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contently.Core.Data.Interfaces;
using Contently.Core.Domain;
using Contently.Core.DiscoveryServices;

namespace Contently.Controllers
{
    public class PageController : Controller
    {
        //public IActionResult Index(string slug, string template = null)
        //{
        //    return View();
        //}

        private readonly IContentDataService<RoutablePage> dataService;
        private readonly IContentTypeDiscoveryService discoveryService;

        public PageController(IContentDataService<RoutablePage> dataService, IContentTypeDiscoveryService discoveryService)
        {
            this.dataService = dataService;
            this.discoveryService = discoveryService;
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

        public IActionResult GetContentTypes()
        {
            return Ok(discoveryService.Discover());
        }


    }
}