using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServeyEmail.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Getdata()
        {
            Ratio q = new Ratio();
            q.a = 30;
            q.b = 49;
            q.c = 50;
            return Json(q, JsonRequestBehavior.AllowGet);

        }
        public class Ratio
        {
            public int a { get; set; }
            public int b { get; set; }
            public int c { get; set; }
        }
    }
}