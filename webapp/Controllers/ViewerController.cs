using Architect.API.Core.Security;
using aliados.Filters;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class ViewerController : Controller
    {
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Architect.Utilities.Helpers.Settings.StringValue("Message")))
            {
                ViewBag.AlertMessage = Architect.Utilities.Helpers.Settings.StringValue("Message");
            }
            return View();
        }

        public ActionResult Render()
        {
            return View();
        }
     
        public ActionResult Viewer()
        {
            bool _viewType = false;
            ViewBag.inboxClass = "";
            ViewBag.iboxContentClass = "";
            bool.TryParse(Request.QueryString["ViewType"], out _viewType);
            if (_viewType)
            {
                ViewBag.InboxClass = "ibox";
                ViewBag.IboxContentClass = "ibox-content";
            }
            ViewBag.ViewType = _viewType;

            if (!string.IsNullOrEmpty(Architect.Utilities.Helpers.Settings.StringValue("Message")))
            {
                ViewBag.AlertMessage = Architect.Utilities.Helpers.Settings.StringValue("Message");
            }
            return View();
        }

        public ActionResult Tab()
        {
            return View();
        }

        public ActionResult TabRender()
        {
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }
        public ActionResult Formio()
        {
            return View();
        }
        public ActionResult FormBuilder()
        {
            return View();
        }
        public ActionResult FormDefine()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult crud()
        {
            return View("crud");
        }
    }
}