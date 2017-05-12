using SportsWebsite.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SportsWebsite.Models
{
    public class TeamDetailsModel :IEntity
    {
        public string TeamName { get; set; }
        public int Id { get; set; }

        public void SetFeilds(DataRow dataRow)
        {
            TeamName = (string)dataRow["TeamName"];
            Id = (int)dataRow["Id"];
        }
    }
}