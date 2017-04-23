using SportsWebsite.Models;
using SportsWebsite.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SportsWebsite.Data
{
    public class Repository
    {
        private DataAccess dataAccess = null;

        public Repository()
        {
            dataAccess = new DataAccess();
        }

        public bool ValidateUser(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");

            object obj = null;
            try
            {
                string sql = "select Username from Login where Username=@userName" +
                    " and Password=@password";
                List<DbParameter> PList = new List<DbParameter>();
                DbParameter p1 = new SqlParameter("@userName", SqlDbType.VarChar, 50);
                p1.Value = userName;
                PList.Add(p1);
                DbParameter p2 = new SqlParameter("@password", SqlDbType.VarChar, 50);
                p2.Value = password;
                PList.Add(p2);

                obj = dataAccess.GetSingleAnswer(sql, PList);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj != null ? true : false;
        }

        public List<NewsFeed> GetFeeds(string catID)
        {
            List<NewsFeed> TList = null;
            try
            {
                if (TList == null)
                {
                    DataTable dataTable = GetNewsFeed(catID);
                    TList = RepositoryHelper.ConvertToList<NewsFeed>(dataTable);
                    if (TList != null)
                    {
                        List<ImageModel> ImageList = null;
                        foreach (var item in TList)
                        {
                            DataTable imageTable = GetImages(item.Id);
                            ImageList = RepositoryHelper.ConvertToList<ImageModel>(imageTable);
                            if (ImageList != null && ImageList.Count() > 0)
                                item.Image = ImageList.First<ImageModel>();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return TList;
        }

        private DataTable GetNewsFeed(string catID)
        {
            DataTable dataTable = null;
            try
            {
                string sql = "";
                List<DbParameter> PList = new List<DbParameter>();
                if (String.IsNullOrEmpty(catID))
                {
                    sql = "select * from products";
                }
                else
                {
                    sql = "select * from  products where catid=@catID";
                    DbParameter p1 = new SqlParameter("@catID", SqlDbType.VarChar, 50);
                    p1.Value = catID;
                    PList.Add(p1);
                }
                dataTable = dataAccess.GetDataTable(sql, PList);
            }
            catch (Exception)
            {
                throw;
            }
            return dataTable;
        }

        private DataTable GetImages(int Id)
        {
            DataTable dataTable = null;
            try
            {
                string sql = "select * from images where newsId=@newsId";
                List<DbParameter> PList = new List<DbParameter>();
                DbParameter p1 = new SqlParameter("@newsId", SqlDbType.Int);
                p1.Value = Id;
                PList.Add(p1);

                dataTable = dataAccess.GetDataTable(sql, PList);
            }
            catch (Exception)
            {
                throw;
            }
            return dataTable;
        }
    }
}