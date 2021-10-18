using System.Web.Mvc;

namespace Controllers.Models
{
    public class CaptchaValidator : ActionFilterAttribute
    {
        private const string RECAPTCHA_CHALLENGE_FIELD = "recaptcha_challenge_field";
        private const string RECAPTCHA_RESPONSE_FIELD = "recaptcha_response_field";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var captchaChallengeValue = filterContext.HttpContext.Request.Form[RECAPTCHA_CHALLENGE_FIELD];
            var captchaResponseValue = filterContext.HttpContext.Request.Form[RECAPTCHA_RESPONSE_FIELD];

            var captchaValidator = new Recaptcha.RecaptchaValidator
            {
                PrivateKey = "6LdIh8ASAAAAAG--c89B3IXtZobIc2pgInT5Rcqk",
                RemoteIP = filterContext.HttpContext.Request.UserHostAddress,
                Challenge = captchaChallengeValue,
                Response = captchaResponseValue
            };
            var recapthaResponse = captchaValidator.Validate();

            filterContext.ActionParameters["captchaValid"] = recapthaResponse.IsValid;

            base.OnActionExecuting(filterContext);
        }
    }
}