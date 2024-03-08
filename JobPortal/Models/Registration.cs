using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace JobPortal.Models
{
    public class Registration
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public string Dateofbirth { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phonenumber")]
        public string Phonenumber { get; set; }


        [Display(Name = "State")]
        public string State { get; set; }

   
        [Display(Name = "City")]
        public string City { get; set; }

     
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

      
        [Display(Name = "Confirmpassword")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string Confirmpassword { get; set; }



    }
}