using SportsWebsite.Data;
using SportsWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsWebsite.Business
{
    public class BusinessShop
    {
        private Repository repo = null;

        public BusinessShop()
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
        public List<NewsFeedModel> GetProducts(string catID)
        {
            List<NewsFeedModel> TList = new List<NewsFeedModel>();
            TList = repo.GetFeeds(catID);
            return TList;
        }

        public bool AddNewsFeed(NewsFeedModel model)
        {
            return repo.AddNewsFeed(model);
        }
        #endregion
    }
}