using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace JobPortal.Models
{
    public class Signin
    {

            public int Id { get; set; }


            [Required(ErrorMessage = "Enter the Username")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [Display(Name = "Password")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            public bool Admin { get; set; }
        }
}