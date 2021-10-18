using System.Web.Mvc;
using BusinessObjects;

namespace Controllers.Controllers
{
    public class BaseController : Controller
    {
        protected ModelEntities ModelEntities = new ModelEntities();

        protected override void HandleUnknownAction(string actionName)
        {
            actionName = "Error";
            this.View(actionName).ExecuteResult(ControllerContext);
        }
    }
}
