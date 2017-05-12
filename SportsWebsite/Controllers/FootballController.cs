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
            string leagueId = Request.Form["leagueModel[0].leagueName"];
            //var league = model.leagueModel[0].leagueName;
            int Id = Convert.ToInt32(leagueId);
            fList = business.footballTables(Id);

            model.footballTableModel = fList;
            model.leagueModel = fList1;
            return View(model);
        }
        public ActionResult FootballTeams()
        {
            List<TeamTypeModel> fList = new List<TeamTypeModel>();
            fList = business.GetClubs();
            TeamModel model = new TeamModel();
            model.teamTypeModel = fList;
            return View(model);
        }

        [HttpPost]
        public ActionResult FootballTeams(TeamModel model)
        {
            List<TeamTypeModel> fList1 = new List<TeamTypeModel>();
            fList1 = business.GetClubs();
            List<TeamDetailsModel> fList = new List<TeamDetailsModel>();
            string myId = Request.Form["teamTypeModel[0].Type"];
            //var league = model.leagueModel[0].leagueName;
            int Id = Convert.ToInt32(myId);
            fList = business.GetTeams(Id);

            model.teamDetailsModel = fList;
            model.teamTypeModel = fList1;
            return View(model);
        }
    }
}