using System;
using System.Web.Routing;
using CMS.Routing;

namespace CMS
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
#if CONSOLE
            //ConsoleManager.InitializeConsoleManager();
#endif
            RegisterRoutes();
        }

        private static void RegisterRoutes()
        {
            RouteTable.Routes.Add(
                "ViewTable",
                new Route("View/{name}",
                          new TableViewRouteHandler(
                              "~/ViewTable.aspx")));

            RouteTable.Routes.Add(
                "EditTable",
                new Route("Edit/{name}/{action}/{id}",
                          new TableEditRouteHandler(
                              "~/EditRowData.aspx")));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Server.Transfer("Error.aspx");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}