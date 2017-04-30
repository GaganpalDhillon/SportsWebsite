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
        private BusinessShop business = null;

        protected override void Initialize(RequestContext requestContext)
        {
            business = new BusinessShop();
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

        public ActionResult Admin()
        {
            NewsFeedModel newfeedmodel = new NewsFeedModel();
            newfeedmodel.Cat = new List<Category>();
            newfeedmodel.Cat = GetAllCatgeory();
            return View(newfeedmodel);
        }

        [HttpPost]
        public  ActionResult GetSubByCategory(int catId)
        {
            List<SubCategory> subcategory = new List<SubCategory>();
            subcategory = GetAllSubCategory().Where(m => m.CatId == catId).ToList();
            SelectList objList = new SelectList(subcategory, "Id", "SubCategoryName", 0);
            return Json(objList);

        }

        public List<Category> GetAllCatgeory()
        {
            List<Category> objCat = new List<Category>();
            objCat.Add(new Category { Id = 0, CategoryName = "Select Catgeory" });
            objCat.Add(new Category { Id = 1, CategoryName = "Football" });
            objCat.Add(new Category { Id = 2, CategoryName = "Formula1" });
            return objCat;
        }

        public List<SubCategory> GetAllSubCategory()
        {
            List<SubCategory> subCat = new List<SubCategory>();
            subCat.Add(new SubCategory { Id = 1, CatId = 1, SubCategoryName = "Results" });
            subCat.Add(new SubCategory { Id = 2, CatId = 1, SubCategoryName = "Scores" });
            subCat.Add(new SubCategory { Id = 3, CatId = 2, SubCategoryName = "Cars" });
            subCat.Add(new SubCategory { Id = 4, CatId = 2, SubCategoryName = "Fixes" });
            return subCat;
        }
    }
}