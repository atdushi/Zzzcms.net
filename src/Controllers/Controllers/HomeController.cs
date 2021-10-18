using System;
using System.Linq;
using System.Web.Mvc;
using Controllers.Models;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Collections;
using System.ServiceModel.Syndication;

namespace Controllers.Controllers
{
    [HandleError]
    public class HomeController : BaseController
    {
        /// <summary>
        /// Manages all "Pages"
        /// </summary>
        /// <param name="id">MenuAndPages id</param>
        /// <returns></returns>
        [FillMasterPageViewData]
        public ActionResult Index(int id)
        {
            Session["PageId"] = id;

            var pages = ModelEntities.MenuAndPages.Select(m => m).Where(m => m.Id == id);

            foreach (var page in pages)
            {
                if (!String.IsNullOrEmpty(page.Handler)
                    && page.Handler.Trim() != "null")
                {
                    try
                    {
                        var ht = new Hashtable();

                        var handlerParse = Regex.Split(page.Handler, ";");
                        var string1Parse = Regex.Split(handlerParse[0], "=");
                        var string2Parse = Regex.Split(handlerParse[1], "=");

                        ht.Add(string1Parse[0], string1Parse[1]);
                        ht.Add(string2Parse[0], string2Parse[1]);

                        return RedirectToAction(ht["action"].ToString(), ht["controller"].ToString());
                    }
                    catch { }
       
                }
                break;
            }
            return View("Index");
        }

        /// <summary>
        /// RSS
        /// </summary>
        /// <returns></returns>
        public ActionResult Feed()
        {
            var feed =
                new SyndicationFeed("ZZZCMS RSS",
                                    "subscription",
                                    null,
                                    Guid.NewGuid().ToString(),
                                    DateTime.Now);

            var items = ModelEntities
                .News
                .Select(n => n)
                .Select(news => 
                    new SyndicationItem(news.Title, news.Text, null, Guid.NewGuid().ToString(), news.Date)).ToList();

            feed.Items = items;

            return new RssActionResult() { Feed = feed };
        }

        #region user_authentication
        public ActionResult LogOn(LogOnModel model)
        {
            if (Membership.ValidateUser(model.UserName, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
            }

            return RedirectToAction("Index");
        }
        
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index");
        }
        #endregion user_authentication

        #region Actions for "Custom Page" Feedback

        [FillMasterPageViewData]
        public ActionResult Feedback()
        {
            return View("Feedback");
        }

        [CaptchaValidator]
        [FillMasterPageViewData]
        public ActionResult SendFeedback(FeedbackMessage message, bool captchaValid)
        {
            if (String.IsNullOrEmpty(message.Name))
            {
                ModelState.AddModelError("Name", "Name is required.");
            }
            if (String.IsNullOrEmpty(message.Email))
            {
                ModelState.AddModelError("Email", "Email is required.");
            }
            if (String.IsNullOrEmpty(message.Comment))
            {
                ModelState.AddModelError("Comment", "Comment is required.");
            }
            else
            {
                if (!captchaValid)
                {
                    ModelState.AddModelError("Capthca", "Invalid capthca.");
                }
            }

            if (!ModelState.IsValid)
            {
                return View("Feedback");
            }

            try
            {
                MailSender.SendMail(message);
            }
            catch{ }

            return RedirectToAction("Index", new { id = 1 });
        }
        #endregion
    }
}
