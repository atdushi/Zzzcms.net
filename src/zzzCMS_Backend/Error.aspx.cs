using System;

namespace CMS
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("ERROR: " + Server.GetLastError().Message);
            Trace.Write("ERROR: " + Server.GetLastError().Message);
            Server.ClearError();
        }
    }
}
