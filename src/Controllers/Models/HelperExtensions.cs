using System.IO;
using System.Web.Mvc;
using System.Web.UI;

namespace Controllers.Models
{
    public static class HelperExtensions
    {
        public static string CaptchaImage(this HtmlHelper helper)
        {
            var imgTagBuilder = new TagBuilder("img");
            imgTagBuilder.MergeAttribute("src", "../../AntiBotImage.ashx");
            imgTagBuilder.MergeAttribute("alt", "anti bot image");
            return imgTagBuilder.ToString();
        }

        public static string ActionLinkWithImage(this  HtmlHelper html, string imgSrc, string actionName)
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var imgUrl = urlHelper.Content(imgSrc);
            var imgTagBuilder = new TagBuilder("img");
            imgTagBuilder.MergeAttribute("src", imgUrl);
            imgTagBuilder.MergeAttribute("style", "border-style: none");
            var img = imgTagBuilder.ToString(TagRenderMode.Normal);
            var url = urlHelper.Action(actionName);

            var tagBuilder = new TagBuilder("a")
                                        {
                                            InnerHtml = img
                                        };

            tagBuilder.MergeAttribute("href", url);
            return tagBuilder.ToString(TagRenderMode.Normal);
        }

        public static string GenerateRecaptcha(this HtmlHelper helper)
        {
            var recaptchaControl = new Recaptcha.RecaptchaControl
            {
                ID = "recaptcha",
                PublicKey = "6LdIh8ASAAAAAPfYi69Gikt2cKefuf1aB1E4olIN",
                PrivateKey = "6LdIh8ASAAAAAG--c89B3IXtZobIc2pgInT5Rcqk"
            };

            var stringWriter = new StringWriter();
            var htmlTextWriter = new HtmlTextWriter(stringWriter);

            recaptchaControl.RenderControl(htmlTextWriter);

            return htmlTextWriter.InnerWriter.ToString();
        }
    }
}
