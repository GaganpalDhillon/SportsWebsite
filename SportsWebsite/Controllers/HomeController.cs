using SportsWebsite.Business;
using SportsWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsWebsite.Controllers
{
    public class HomeController : Controller
    {
        BusinessNews business = null;

        protected override void Initialize(RequestContext requestContext)
        {
            business = new BusinessNews();
            base.Initialize(requestContext);
        }

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

        public ActionResult Admin()
        {
            NewsFeedModel newfeedmodel = new NewsFeedModel();
            return View(newfeedmodel);
        }

        [HttpPost]
        public ActionResult Admin(NewsFeedModel model)
        {
            if (ModelState.IsValid)
            {
                if (business.AddNewsFeed(model))
                    model.Status = "Your news has been added successfully.";
                else
                    model.Status = "News could not be added.";
            }
            return View(model);
        }

    }
}