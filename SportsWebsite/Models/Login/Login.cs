using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsWebsite.Models.Login
{
    public class Login
    {
        [Required(ErrorMessage = "Username is required!!")]
            public string Username { get; set; }
        [Required(ErrorMessage = "Password is required!!")]
        public string Password { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}