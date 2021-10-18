<%@ WebHandler Language="C#" Class="BannerImage" %>

using System.Web;
using System.Web.SessionState;
using System.Drawing;
using System.Drawing.Imaging;

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
