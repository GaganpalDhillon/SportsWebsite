using SportsWebsite.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SportsWebsite.Models
{
    public class NewsFeedModel : IEntity
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public int Subcategory { get; set; }
        public string Heading { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public ImageModel Image { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }

        #region IEntity members
        public void SetFeilds(DataRow dataRow)
        {
            Id = (int)dataRow["NewsId"];
            Category = (int)dataRow["CatagoryId"];
            Heading = (string)dataRow["Heading"];
            Author = (string)dataRow["Author"];
            Date = (DateTime)dataRow["DateTime"];
            ShortDesc = (string)dataRow["short"];
            LongDesc = (string)dataRow["story"];
        }
        #endregion
    }
}
