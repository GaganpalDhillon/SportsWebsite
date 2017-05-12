using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsWebsite.Models
{
    public class TableModel
    {
        public List<FootballTableModel> footballTableModel = new List<FootballTableModel>();
        public List<LeagueModel> leagueModel = new List<LeagueModel>();
    }
}