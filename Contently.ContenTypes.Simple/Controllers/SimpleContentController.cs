using System;
using Contently.Core.Data.Interfaces;
using Contently.Core.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contently.ContentTypes.Simple.Controllers
{
    public class SimpleContentController : Controller
    {
        private readonly IContentDataService<RoutablePage> dataService;

        public SimpleContentController(IContentDataService<RoutablePage> dataService) { this.dataService = dataService; }

        // GET: /<controller>/
        public IActionResult SimpleContentView(Guid pageId)
        {
            var content = dataService.GetOne(pageId);
            return View("Index", content);
        }

        public IActionResult SimpleContentEditView(Guid pageId)
        {
            var content = dataService.GetOne(pageId);
            return View("Edit", content);
        }

        public IActionResult SimpleContentWithImageListView(Guid pageId)
        {
            var content = dataService.GetOne(pageId);
            return View("List", content);
        }

        public IActionResult SimpleContentWithImageListEditView(Guid pageId)
        {
            var content = dataService.GetOne(pageId);
            return View("EditList", content);
        }
        

    }
}
