using System;

namespace CMS
{
    public partial class CMS : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string PageRenderTime
        {
            get
            {
                try
                {
                    PageBase pageBase = this.ContentPlaceHolder1.Page as PageBase;
                    return pageBase.PageRenderTime;
                }
                catch
                {
                    return "";
                }
            }
        }
    }
}
