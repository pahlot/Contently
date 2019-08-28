using Contently.Core.Data.Interfaces;
using Contently.Core.Domain;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Contently.Core.Web.Routing
{
    public class UrlSlugRoute : IRouter
    {
        private readonly IRouter _target;

        public UrlSlugRoute(IRouter target)
        {
            _target = target;
        }

        

        public async Task RouteAsync(RouteContext context)
        {
            var requestPath = context.HttpContext.Request.Path.Value;

            // TODO: Add a lookup for a content managed root/home page
            if (!string.IsNullOrEmpty(requestPath) && requestPath[0] == '/')
            {
                // Trim the leading slash
                requestPath = requestPath.Substring(1);
            }

            //var urlSlugRepository = context.HttpContext.RequestServices.GetService<IRepository<Entity>>();
            var urlSlugRepository = context.HttpContext.RequestServices.GetService<IDataService<RoutablePage>>();

            // Get the slug that matches.
            //var urlSlug = await urlSlugRepository.Query().Include(x => x.EntityType).FirstOrDefaultAsync(x => x.Slug == requestPath);
            var page = urlSlugRepository.FindOne(x => x.Slug == requestPath.ToLower());

            // Invoke MVC controller/action
            var oldRouteData = context.RouteData;
            var newRouteData = new RouteData(oldRouteData);
            newRouteData.Routers.Add(_target);

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

                if (page.IsPublished)
                {
                    newRouteData.Values["action"] = "Index"; // urlSlug.EntityType.RoutingAction;
                }
                else
                {
                    newRouteData.Values["action"] = "Draft"; // urlSlug.EntityType.RoutingAction;
                }
                newRouteData.Values["id"] = page.Id;
            }


            context.RouteData = newRouteData;
            await _target.RouteAsync(context);
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }
    }
}
