using System.Xml;
using System.ServiceModel.Syndication;
using System.Web.Mvc;

namespace Controllers.Models
{
    public class RssActionResult : ActionResult
    {
        public SyndicationFeed Feed { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/rss+xml";

            var rssFormatter = new Rss20FeedFormatter(Feed);
            using (var writer = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                rssFormatter.WriteTo(writer);
            }
        }
    }

}
