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
    public class FootballController : Controller
    {
        private BusinessNews business = null;
        protected override void Initialize(RequestContext requestContext)
        {
            business = new BusinessNews();
            base.Initialize(requestContext);
        }

        // GET: Football
        //public ActionResult Football()
        //{
        //    return View("Football");
        //}
        public ActionResult Football()
        {
            List<NewsFeedModel> NList = new List<NewsFeedModel>();
            NList = business.GetFeeds("1");
            return View(NList);
        }

        public ActionResult NewsDesc()
        {
            string Id = Session["Sample"].ToString();
            
            List<NewsFeedModel> NList = new List<NewsFeedModel>();
            NList = business.GetDesc(Id);
            return View(NList);
        }
        public ActionResult FootballTable()
        {
            List<LeagueModel> fList = new List<LeagueModel>();
            fList = business.GetLeagueNames();
            TableModel model = new TableModel();
            model.leagueModel = fList;
            return View(model);
        }

        [HttpPost]
        public ActionResult FootballTable(TableModel model)
        {
            List<LeagueModel> fList1 = new List<LeagueModel>();
            fList1 = business.GetLeagueNames();
            List<FootballTableModel> fList = new List<FootballTableModel>();
           //string leagueName = Request.Form["league"].ToString(); 
            fList = business.footballTables("English Premier League");

            model.footballTableModel = fList;
            model.leagueModel = fList1;
            return View(model);
        }
    }
}