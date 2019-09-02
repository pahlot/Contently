using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contently.Core.Data.Interfaces;
using Contently.Core.DiscoveryServices;
using Contently.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Contently.Web.Admin.Controllers
{
    [Area("ContentlyAdmin")]
    public class AdminController : Controller
    {

        private readonly IContentDataService<RoutablePage> dataService;
        private readonly IContentTypeDiscoveryService discoveryService;

        public AdminController(IContentDataService<RoutablePage> dataService, IContentTypeDiscoveryService discoveryService)
        {
            this.dataService = dataService;
            this.discoveryService = discoveryService;
        }

        public async Task<IActionResult> GetContentTypes()
        {
            return Ok(discoveryService.Discover());
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}