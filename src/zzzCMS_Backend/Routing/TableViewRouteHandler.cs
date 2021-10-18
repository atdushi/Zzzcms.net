using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Net;
using System.Web.Compilation;
using System.Web.UI;

namespace CMS.Routing
{
    public class TableViewRouteHandler : IRouteHandler
    {
        readonly string _virtualPath;

        public TableViewRouteHandler(string virtualPath)
        {
            _virtualPath = virtualPath;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            if (!UrlAuthorizationModule.CheckUrlAccessForPrincipal(
               _virtualPath, requestContext.HttpContext.User,
                             requestContext.HttpContext.Request.HttpMethod))
            {
                requestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                requestContext.HttpContext.Response.End();
            }

            var display = BuildManager.CreateInstanceFromVirtualPath(
                            _virtualPath, typeof(Page)) as ITableView;

            display.TableName = requestContext.RouteData.Values["name"] as string;
            return display;
        }


    }
}
