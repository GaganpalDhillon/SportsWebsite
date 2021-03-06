﻿using SportsWebsite.Data;
using SportsWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsWebsite.Business
{
    public class BusinessNews
    {
        private Repository repo = null;

        public BusinessNews()
        {
            repo = new Repository();
        }

        #region Authenticate
        public bool ValidateUser(string user, string password)
        {
            return repo.ValidateUser(user, password);
        }
        #endregion

        #region NewsFeed
        public List<NewsFeedModel> GetFeeds(string catID)
        {
            List<NewsFeedModel> TList = new List<NewsFeedModel>();
            TList = repo.GetFeeds(catID);
            return TList;
        }
        public List<NewsFeedModel> GetDesc(string NewsId)
        {
            List<NewsFeedModel> NList = new List<NewsFeedModel>();
            NList = repo.GetDesc(NewsId);
            return NList;
        }

        public List<FootballTableModel> footballTables(int leagueId)
        {
            List<FootballTableModel> fList = new List<FootballTableModel>();
            fList = repo.footballTables(leagueId);
            return fList;
        }

        public List<LeagueModel> GetLeagueNames()
        {
            List<LeagueModel> lList = new List<LeagueModel>();
            lList = repo.GetLeagueNames();
            return lList;
        }
        public List<TeamDetailsModel> GetTeams(int Id)
        {
            List<TeamDetailsModel> tdList = new List<TeamDetailsModel>();
            tdList = repo.GetTeams(Id);
            return tdList;
        }
        public List<TeamTypeModel> GetClubs()
        {
            List<TeamTypeModel> ttList = new List<TeamTypeModel>();
            ttList = repo.GetClubs();
            return ttList;
        }
        public bool AddNewsFeed(NewsFeedModel model)
        {
            return repo.AddNewsFeed(model);
        }
        #endregion
    }
}
