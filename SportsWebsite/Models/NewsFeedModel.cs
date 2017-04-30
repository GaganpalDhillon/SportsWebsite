using SportsWebsite.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace SportsWebsite.Models
{
    public class NewsFeedModel : IEntity
    {
        
        public int Id { get; set; }
      //  [Display(Name = "Category")]
       // public int Category { get; set; }
        [Display(Name = "Subcategory")]
        public int Subcategory { get; set; }

        [Required(ErrorMessage = "Heading is required..")]
        [Display(Name = "Heading")]
        public string Heading { get; set; }
        [Display(Name = "Author")]
        public string Author { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Display(Name = "Image")]
        public ImageModel Image { get; set; }
        [Display(Name = "ShortDesc")]
        public string ShortDesc { get; set; }
        [Display(Name = "LongDesc")]
        public string LongDesc { get; set; }
        [Display(Name = "Category")]
        public List<Category> Cat { get; set; }

        public class Category :IEntity
        {
            public int Id { get; set; }
           
            public string CategoryName { get; set; }

            public void SetFeilds(DataRow dataRow)
            {
                throw new NotImplementedException();
            }
        }
        public class SubCategory :IEntity
        {
            public int Id { get; set; }
            public int CatId { get; set; }
            [Display(Name = "SubCategory")]
            public string SubCategoryName { get; set; }

            public void SetFeilds(DataRow dataRow)
            {
               SubCategoryName = (string)dataRow["SubCategory"] ;
            }
        }

        #region IEntity members
        public void SetFeilds(DataRow dataRow)
        {
            Id = (int)dataRow["NewsId"];
           // Category = (int)dataRow["CatagoryId"];
            Heading = (string)dataRow["Heading"];
            Author = (string)dataRow["Author"];
            Date = (DateTime)dataRow["DateTime"];
            ShortDesc = (string)dataRow["short"];
            LongDesc = (string)dataRow["story"];
        }
        #endregion
    }
}
