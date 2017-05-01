using SportsWebsite.Business;
using SportsWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using static SportsWebsite.Models.NewsFeedModel;

namespace SportsWebsite.Controllers
{
    public class LoginController : Controller
    {
        private BusinessNews business = null;

        protected override void Initialize(RequestContext requestContext)
        {
            business = new BusinessNews();
            base.Initialize(requestContext);
        }

        // GET: Login
        public ActionResult Login()
        {
            LoginModel loginModel = new LoginModel();
            return View(loginModel);
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                if (business.ValidateUser(loginModel.Username, loginModel.Password))
                    loginModel.Status = "User successfully logged in.";
                else
                    loginModel.Status = "Invalid credentials.";
            }

            return View(loginModel);
        }

        public ActionResult Register()
        {
            return View("Register");
        }
    }
}