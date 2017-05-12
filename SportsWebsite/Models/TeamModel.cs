using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsWebsite.Models
{
    public class TeamModel
    {
        public List<TeamTypeModel> teamTypeModel = new List<TeamTypeModel>();
        public List<TeamDetailsModel> teamDetailsModel = new List<TeamDetailsModel>();
    }
}