using SportsWebsite.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using static DotNetOpenAuth.OpenId.Extensions.AttributeExchange.WellKnownAttributes;
using System.ComponentModel.DataAnnotations;

namespace SportsWebsite.Models
{
    public class FootballTableModel :IEntity
    {
        [Display(Name = "Team")]
        public string Team { get; set; }
        [Display(Name = "Played")]
        public int Played { get; set; }
        [Display(Name = "Win")]
        public int Win { get; set; }
        [Display(Name = "Draw")]
        public int Draw { get; set; }
        [Display(Name = "Lost")]
        public int Lost { get; set; }
        [Display(Name = "GF")]
        public int GoalsFor { get; set; }
        [Display(Name = "GA")]
        public int GoalsAgainst { get; set; }
        [Display(Name = "GD")]
        public int GoalsDifference { get; set; }
        [Display(Name = "Points")]
        public int Points { get; set; }
       
        //public string TeamName { get; set; }
        //public string TeamType { get; set; }
        //public int teamId { get; set; }
        public void SetFeilds(DataRow dataRow)
        {
            Team = (string)dataRow["Team"];
            Played = (int)dataRow["Played"];
            Win = (int)dataRow["Win"];
            Draw = (int)dataRow["Draw"];
            Lost = (int)dataRow["Lost"];
            GoalsFor = (int)dataRow["GoalsFor"];
            GoalsAgainst = (int)dataRow["GoalsAgainst"];
            GoalsDifference = (int)dataRow["GoalDifference"];
            Points = (int)dataRow["Points"];
           
            //TeamName = (string)dataRow["TeamName"];
            //TeamType = (string)dataRow["TeamType"];
            //teamId = (int)dataRow["Id"];
            
        }
    }
}