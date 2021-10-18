<%@ WebHandler Language="C#" Class="BannerImage" %>

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using zzzCMS_Frontend_MVC.CaptchaService;

/// <summary>
/// For future releases.
/// </summary>
public class BannerImage : IHttpHandler, IRequiresSessionState
{
    #region IHttpHandler Members

    public bool IsReusable
    {
        get { return true; }
    }

    public void ProcessRequest(HttpContext context)
    {
        Bitmap bmp = null;
        
        //todo: load bmp from database
        
        bmp.Save(context.Response.OutputStream, ImageFormat.Jpeg);
    }
    
    #endregion
}
