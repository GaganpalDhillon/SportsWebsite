using SportsWebsite.Models;
using SportsWebsite.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
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

        public List<NewsFeedModel> GetFeeds(string catID)
        {
            List<NewsFeedModel> TList = null;
            try
            {
                if (TList == null)
                {
                    DataTable dataTable = GetNewsFeed(catID);
                    TList = RepositoryHelper.ConvertToList<NewsFeedModel>(dataTable);
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
                    sql = "select * from NewsFeed";
                }
                else
                {
                    sql = "select * from  NewsFeed where Category=@catID";
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
        public List<NewsFeedModel> GetDesc(string NewsID)
        {
            List<NewsFeedModel> TList = null;
            try
            {
                if (TList == null)
                {
                    DataTable dataTable = GetNewsDesc(NewsID);
                    TList = RepositoryHelper.ConvertToList<NewsFeedModel>(dataTable);
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
        private DataTable GetNewsDesc(string NewsID)
        {
            DataTable dataTable = null;
            try
            {
                string sql = "";
                List<DbParameter> PList = new List<DbParameter>();
                if (String.IsNullOrEmpty(NewsID))
                {
                    sql = "select * from NewsFeed";
                }
                else
                {
                    sql = "select * from  NewsFeed where Id=@NewsID";
                    DbParameter p1 = new SqlParameter("@NewsID", SqlDbType.VarChar, 50);
                    p1.Value = NewsID;
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
                string sql = "select * from Images where NewsId=@Id";
                List<DbParameter> PList = new List<DbParameter>();
                DbParameter p1 = new SqlParameter("@Id", SqlDbType.Int);
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

        public List<FootballTableModel> footballTables(int leagueId)
        {
            DataTable dataTable = null;
            List<FootballTableModel> fList = new List<FootballTableModel>();
            try
            {
                //string sql = "select leagueId from League where Name = @leagueName";
                //List<DbParameter> Plist = new List<DbParameter>();
                //DbParameter p1 = new SqlParameter("@leagueName", SqlDbType.VarChar, 50);
                //p1.Value = leagueName;
                //Plist.Add(p1);
                //object obj = dataAccess.GetSingleAnswer(sql, Plist);
                //int leagueId = 0;
                //if (obj != null)
                //    leagueId = (int)obj;

                string sql1 = "select * from Tables where leagueId =@leagueId ";
                List<DbParameter> TList = new List<DbParameter>();
                DbParameter p2 = new SqlParameter("@leagueId", SqlDbType.Int);
                p2.Value = leagueId;
                TList.Add(p2);
                dataTable = dataAccess.GetDataTable(sql1, TList);
                fList = RepositoryHelper.ConvertToList<FootballTableModel>(dataTable);
            }
            catch (Exception)
            {
                throw;
            }
            return fList;
            
        }

        public List<LeagueModel> GetLeagueNames()
        {
            DataTable dataTable = null;
            List<LeagueModel> fList = new List<LeagueModel>();
            try
            {
                string sql = "select * from League";
                List<DbParameter> Plist = new List<DbParameter>();
                dataTable = dataAccess.GetDataTable(sql, Plist);
                fList = RepositoryHelper.ConvertToList<LeagueModel>(dataTable);
            }
            catch (Exception)
            {
                throw;
            }
            return fList;
        }
      
        public List<TeamTypeModel> GetClubs()
        {
            DataTable dataTable = null;
            List<TeamTypeModel> tList = new List<TeamTypeModel>();
            try
            {
                string sql = "select * from TeamType";
                List<DbParameter> plist = new List<DbParameter>();
                dataTable = dataAccess.GetDataTable(sql, plist);
                tList = RepositoryHelper.ConvertToList<TeamTypeModel>(dataTable);
            }
            catch (Exception)
            {
                throw;
            }
            return tList;
        }

        public List<TeamDetailsModel> GetTeams(int Id )
        {
            DataTable dataTable = null;
            List<TeamDetailsModel> fList = new List<TeamDetailsModel>();
            try
            {
               
                string sql1 = "select * from TeamDetails where TypeId =@Id ";
                List<DbParameter> TList = new List<DbParameter>();
                DbParameter p2 = new SqlParameter("@Id", SqlDbType.Int);
                p2.Value = Id;
                TList.Add(p2);
                dataTable = dataAccess.GetDataTable(sql1, TList);
                fList = RepositoryHelper.ConvertToList<TeamDetailsModel>(dataTable);
            }
            catch (Exception)
            {
                throw;
            }
            return fList;

        }

        public bool AddNewsFeed(NewsFeedModel model)
        {
            bool res = true;
            string ConnectionString = ConfigurationManager.ConnectionStrings["SportsDB"].ConnectionString;
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlTransaction Transaction = null;

            Stream stream = null;
            FileInfo fileInfo = null;
            Byte[] ImageData = null;

            try
            {
                Connection.Open();
                Transaction = Connection.BeginTransaction();

                string sql2 = "select top 1 Id from NewsFeed order by Id desc";
                object obj = null;
                List<DbParameter> pList = new List<DbParameter>();
                 obj = dataAccess.GetSingleAnswer(sql2, pList);
                int NewsId = 0;
                if (obj != null)
                    NewsId = (int)obj;

                ++NewsId;

                string sql1 = "insert into NewsFeed (Id, Category, SubCategory, Heading, Author, Date, Description)" +
                    "values (@Id, @Category, @SubCategory, @Heading, @Author, @Date, @Description)";
                SqlCommand cmd1 = new SqlCommand(sql1, Connection);

                DbParameter p1 = new SqlParameter("@Id", SqlDbType.Int);
                p1.Value = NewsId;
                cmd1.Parameters.Add(p1);

                DbParameter p2 = new SqlParameter("@Category", SqlDbType.Int);
                p2.Value = model.Id;
                cmd1.Parameters.Add(p2);

                DbParameter p3 = new SqlParameter("@SubCategory", SqlDbType.Int);
                p3.Value = model.Subcategory;
                cmd1.Parameters.Add(p3);

                DbParameter p4 = new SqlParameter("@Heading", SqlDbType.Text);
                p4.Value = model.Heading;
                cmd1.Parameters.Add(p4);

                DbParameter p5 = new SqlParameter("@Author", SqlDbType.VarChar, 100);
                p5.Value = model.Author;
                cmd1.Parameters.Add(p5);

                DbParameter p6 = new SqlParameter("@Date", SqlDbType.DateTime, 50);
                p6.Value = DateTime.Now;
                cmd1.Parameters.Add(p6);

                DbParameter p8 = new SqlParameter("@Description", SqlDbType.Text);
                p8.Value = model.LongDesc;
                cmd1.Parameters.Add(p8);

                cmd1.Transaction = Transaction;
                int rows = cmd1.ExecuteNonQuery();
                if (rows <= 0)
                    throw new Exception("Could not insert news feed");

                stream = model.Image.ImageFile.InputStream;
                fileInfo = new FileInfo(Path.GetFullPath(model.Image.ImageFile.FileName));
                ImageData = new Byte[model.Image.ImageFile.ContentLength];
                stream.Read(ImageData, 0, model.Image.ImageFile.ContentLength);

                string sql4 = "select top 1 Id from Images order by Id desc";
                object obj1 = null;
                List<DbParameter> pList1 = new List<DbParameter>();
                obj1 = dataAccess.GetSingleAnswer(sql4, pList1);
                int ImageId = 0;
                if (obj1 != null)
                    ImageId = (int)obj1;

                ++ImageId;

                string sql3 = "insert into images (Id, Name, Type, Image, NewsId) values" +
                    "(@Id, @Name, @Type, @Image, @NewsId)";

                SqlCommand cmd2 = new SqlCommand(sql3, Connection);

                DbParameter p0b = new SqlParameter("@Id", SqlDbType.VarChar, 50);
                p0b.Value = ImageId;
                cmd2.Parameters.Add(p0b);

                DbParameter p1b = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                p1b.Value = fileInfo.Name;
                cmd2.Parameters.Add(p1b);

                DbParameter p2b = new SqlParameter("@Type", SqlDbType.VarChar, 10);
                p2b.Value = fileInfo.Extension;
                cmd2.Parameters.Add(p2b);

                DbParameter p3b = new SqlParameter("@Image", SqlDbType.VarBinary);
                p3b.Value = ImageData;
                cmd2.Parameters.Add(p3b);

                DbParameter p4b = new SqlParameter("@NewsId", SqlDbType.Int);
                p4b.Value = NewsId;
                cmd2.Parameters.Add(p4b);

                cmd2.Transaction = Transaction;
                rows = cmd2.ExecuteNonQuery();
                if (rows <= 0)
                    throw new Exception("Could not insert image.");

                Transaction.Commit();
            }
            catch (Exception e)
            {
                res = false;
                if (Transaction != null)
                    Transaction.Rollback();
                throw e;
            }
            finally
            {
                if (Transaction != null)
                    Transaction.Dispose();

                Connection.Close();
            }
            return res;
        }
    }
}