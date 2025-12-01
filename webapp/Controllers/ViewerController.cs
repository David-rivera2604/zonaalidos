using Architect.API.Core.Security;
using System.Configuration;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    public class ViewerController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            
            if (!string.IsNullOrEmpty(Architect.Utilities.Helpers.Settings.StringValue("Message")))
            {
                ViewBag.AlertMessage = Architect.Utilities.Helpers.Settings.StringValue("Message");
            }
            return View();
        }

        public ActionResult Render()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
     
        public ActionResult Viewer()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
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
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult TabRender()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult Form()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult FormBuilder()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
        public ActionResult FormDefine()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
    }
}