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

        public List<NewsFeed> GetProducts(string catID)
        {
            List<NewsFeed> TList = new List<NewsFeed>();
            TList = repo.GetProducts(catID);
            return TList;
        }
    }
}