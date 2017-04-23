using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsWebsite.Controllers
{
    public class FootballController : Controller
    {
        // GET: Football
        public ActionResult Football()
        {
            return View("Football");
        }
    }
}