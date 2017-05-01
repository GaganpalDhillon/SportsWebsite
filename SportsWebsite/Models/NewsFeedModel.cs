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
        [Display(Name = "Catagory")]
        [Required(ErrorMessage = "Please select a catagory.")]
        public int Id { get; set; }

        [Display(Name = "Subcategory")]
        [Required(ErrorMessage = "Please select a subcatagory.")]
        public int Subcategory { get; set; }

        [Display(Name = "Heading")]
        [Required(ErrorMessage = "Heading is required...")]
        public string Heading { get; set; }

        [Display(Name = "Author")]
        [Required(ErrorMessage = "Please enter Author name.")]
        public string Author { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Image")]
        public ImageModel Image { get; set; }

        [Display(Name = "ShortDesc")]
        public string ShortDesc { get; set; }

        [Display(Name = "LongDesc")]
        public string LongDesc { get; set; }

        public string Status { get; set; }

        #region IEntity members
        public void SetFeilds(DataRow dataRow)
        {
            Id = (int)dataRow["CatagorId"];
            Subcategory = (int)dataRow["Subcatagory"];
            Heading = (string)dataRow["Heading"];
            Author = (string)dataRow["Author"];
            Date = (DateTime)dataRow["DateTime"];
            ShortDesc = (string)dataRow["short"];
            LongDesc = (string)dataRow["story"];
        }
        #endregion
    }
}
