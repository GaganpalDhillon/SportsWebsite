using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SportsWebsite.Utilities
{
    public interface IEntity
    {
        void SetFeilds(DataRow dataRow);
    }
}