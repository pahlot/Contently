using Contently.Core.Data.Interfaces;
using Contently.Core.Domain;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Contently.Core.Web.Routing
{
    public class UrlSlugRoute : IRouter
    {
        private readonly IRouter target;
        private readonly IContentDataService<RoutablePage> dataService;

        public UrlSlugRoute(IRouter target, IContentDataService<RoutablePage> dataService)
        {
            this.target = target;
            this.dataService = dataService;
        }
                
        public async Task RouteAsync(RouteContext context)
        {
            var requestPath = context.HttpContext.Request.Path.Value.ToLower();
            bool isEditMode = false;

            // TODO: Add a lookup for a content managed root/home page
            if (!string.IsNullOrEmpty(requestPath) && requestPath[0] == '/')
            {
                // Trim the leading slash
                requestPath = requestPath.Substring(1);
            }

            if (requestPath.Contains("/edit-content"))
            {
                isEditMode = true;
                requestPath = requestPath.Replace("/edit-content", "");
            }

            // Get the slug that matches.
            var page = dataService.FindOne(x => x.Slug == requestPath.ToLower());

            // Invoke MVC controller/action
            var oldRouteData = context.RouteData;
            var newRouteData = new RouteData(oldRouteData);
            newRouteData.Routers.Add(target);

            // If we got back a null, so we're dealing with a 404 or request for another page we don't manage
            if (page == null)
            {
                // return;
                newRouteData.Values["controller"] = "Error"; 
                newRouteData.Values["action"] = "ErrorWithCode"; // urlSlug.EntityType.RoutingAction;
                newRouteData.Values["code"] = 404;
            }
            else { // Managed
                newRouteData.Values["controller"] = page.RoutingController;
                newRouteData.Values["pageId"] = page.Id;

                if (isEditMode) {
                    newRouteData.Values["action"] = page.Content.Template.EditView;
                }
                else if (page.IsPublished)
                {
                    newRouteData.Values["action"] = page.Content.Template.DisplayView; // urlSlug.EntityType.RoutingAction;
                }
                else
                {
                    newRouteData.Values["action"] = "Draft"; // urlSlug.EntityType.RoutingAction;
                }
                newRouteData.Values["id"] = page.Id;
            }


            context.RouteData = newRouteData;
            await target.RouteAsync(context);
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }
    }
}
