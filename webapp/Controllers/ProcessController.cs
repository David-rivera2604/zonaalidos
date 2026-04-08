using Architect.API.Core.Security;
using aliados.Filters;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class ProcessController : Controller
    {
        public ActionResult Diagram()
        {
            return View();
        }
        public ActionResult Instance()
        {
            return View();
        }

        public ActionResult ProcessSpecFlow()
        {
            return View();
        }

        public ActionResult ProcessSpecLink()
        {
            return View();
        }

        public ActionResult ProcessSpecStep()
        {
            return View();
        }

        public ActionResult ProcessSpecStepRole()
        {
            return View();
        }

       public ActionResult ProcessSpecTask()
        {
            return View();
        }

        public ActionResult ProcessEditor()
        {
            return View();
        }

        public ActionResult ProcessSpecSLA()
        {
            return View();
        }

    }
}