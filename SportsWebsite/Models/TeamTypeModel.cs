using SportsWebsite.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace SportsWebsite.Models
{
    public class TeamTypeModel :IEntity
    {
        [Display(Name = "Clubs")]
        public string Type { get; set; }
        public int Id { get; set; }

        public void SetFeilds(DataRow dataRow)
        {
            Type = (string)dataRow["type"];
            Id = (int)dataRow["Id"];
        }
    }
}