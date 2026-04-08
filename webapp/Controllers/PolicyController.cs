using Architect.API.Core.Security;
using aliados.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aliados.Controllers
{
    [IsConnected]
    [SetTheme]
    public class PolicyController : Controller
    {
        public ActionResult Products()
        {
            return View();
        }
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Architect.Utilities.Helpers.Settings.StringValue("Message")))
            {
                ViewBag.AlertMessage = Architect.Utilities.Helpers.Settings.StringValue("Message");
            }
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult UpLoadLoans()
        {
            return View();
        }

        public ActionResult Listv2()
        {
            return View();
        }
        public ActionResult Listv3()
        {
            return View();
        }

        public ActionResult sample()
        {
            return View();
        }

        public ActionResult Imports()
        {
            return View();
        }

    }
}