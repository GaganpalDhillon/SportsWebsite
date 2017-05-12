using SportsWebsite.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace SportsWebsite.Models
{
    public class LeagueModel: IEntity
    {
        public int leagueId { get; set; }
        [Display(Name = "League")]
        public string leagueName { get; set; }

        public void SetFeilds(DataRow dataRow)
        {
            leagueId = (int)dataRow["leagueId"];
             leagueName = (string)dataRow["Name"];
        }
    }
}