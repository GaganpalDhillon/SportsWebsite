using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace SportsWebsite.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage ="First name is required!!")]
        [StringLength(50, ErrorMessage ="Length can't exceed 50 characters")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required ...")]
        [StringLength(50, ErrorMessage = "Length can't exceed 50 charectars")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required..")]
        [StringLength(100, ErrorMessage = "Length cannot exceed 100 chars")]
        [Display(Name = "Address")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Email is required ...")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required..")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required..")]
        [StringLength(128, ErrorMessage = "The {0} must be atleast {2} characters long", MinimumLength = 8)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [CompareAttribute("Password", ErrorMessage = "Passwords don't match.")]
        public string ConfirmPwd { get; set; }

        [Display(Name = "Password Hint Question")]
        public string PasswordHintQ { get; set; }

        [Display(Name = "Password Hint Answer")]
        public string PasswordHintA { get; set; }

        public string Status { get; set; }

        public void SetFeilds(DataRow dataRow)
        {
            FirstName = (string)dataRow["FirstName"];
            LastName = (string)dataRow["LastName"];
            StreetAddress = (string)dataRow["Address"];
            Email = (string)dataRow["Email"];
        }

    }
}