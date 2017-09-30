using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using DevTrends.MvcDonutCaching;

namespace DonutCacheWebApp.Controllers
{
    public class HomeController : Controller
    {



        [DonutOutputCache(Duration = 20, Location = OutputCacheLocation.Server)]
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

        public PartialViewResult _GetDateTime()
        {
            return PartialView();
        }
    }
}