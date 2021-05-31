using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aliados.Controllers
{
    public class PolicyController : Controller
    {
        public ActionResult Products()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
        public ActionResult Index()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult Edit()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
        public ActionResult UpLoadLoans()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult Listv2()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
        public ActionResult Listv3()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }

        public ActionResult sample()
        {
            ViewBag.theme = ConfigurationManager.AppSettings["app.theme"];
            return View();
        }
    }
}