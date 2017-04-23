using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SportsWebsite.Utilities
{
    public class RepositoryHelper
    {
        public static List<T> ConvertToList<T>(DataTable dataTable)
           where T : IEntity, new()
        {
            List<T> TList = new List<T>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                T item = new T();
                item.SetFeilds(dataRow);
                TList.Add(item);
            }

            return TList;
        }
    }
}