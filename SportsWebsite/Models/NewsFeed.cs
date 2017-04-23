using SportsWebsite.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SportsWebsite.Models
{
    public class NewsFeed : IEntity
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public int Subcategory { get; set; }
        public string Heading { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public Byte[] Image { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }

        public void SetFeilds(DataRow dataRow)
        {
            throw new NotImplementedException();
        }
    }
}
