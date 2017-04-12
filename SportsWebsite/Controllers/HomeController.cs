using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsWebsite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetView()
        {
            return View("HomeView");
        }

        public string GetString()
        {
            return "Hey Adnan";
        }
        public ActionResult Football()
        {
            return View("FootballMain");
        }
    }
}