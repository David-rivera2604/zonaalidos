using System.Configuration;
using System.Web.Mvc;

namespace aliados.Filters
{
    public class SetThemeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            if (controller != null)
            {
                controller.ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
