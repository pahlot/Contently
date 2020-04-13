using Contently.Core.Data.Interfaces;
using Contently.Core.Domain;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Contently.Core.Web.Routing
{
    public class UrlSlugRouter : IRouter
    {
        private readonly IRouter target;
        private readonly IContentDataService<RoutablePage> dataService;
        private readonly IRouteStore routeStore;

        public UrlSlugRouter(IRouter target, IContentDataService<RoutablePage> dataService, IRouteStore routeStore)
        {
            this.target = target;
            this.dataService = dataService;
            this.routeStore = routeStore;
        }
                
        public async Task RouteAsync(RouteContext context)
        {
            // Invoke MVC controller/action
            var oldRouteData = context.RouteData;
            var newRouteData = new RouteData(oldRouteData);
            newRouteData.Routers.Add(target);

            var requestPath = context.HttpContext.Request.Path.Value.ToLower();
            bool isEditMode = false;

            if (requestPath.Contains("/edit-content"))
            {
                isEditMode = true;
                requestPath = requestPath.Replace("/edit-content", "");
            }

            string routableSlug = requestPath.ToLower();

            var pageId = routeStore.GetPageForRequest(routableSlug, context.HttpContext.Request.Host.Host);

            if (pageId.HasValue)
            {
                // Get the slug that matches.
                var page = dataService.FindOne(x => x.Id == pageId);
                
                // If we got back a null, so we're dealing with a 404 or request for another page we don't manage
                if (page != null)
                {
                    // Managed
                    newRouteData.Values["controller"] = page.RoutingController;
                    newRouteData.Values["pageId"] = page.Id;

                    if (isEditMode)
                    {
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
                else
                {
                    set404(newRouteData);
                }
            }
            else
            {
                set404(newRouteData);
            }

            context.RouteData = newRouteData;
            await target.RouteAsync(context);
        }

        private void set404(RouteData newRouteData)
        {
            newRouteData.Values["controller"] = "Error";
            newRouteData.Values["action"] = "ErrorWithCode"; // urlSlug.EntityType.RoutingAction;
            newRouteData.Values["code"] = 404;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }
    }
}
