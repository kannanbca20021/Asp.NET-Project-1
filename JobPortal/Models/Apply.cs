using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace JobPortal.Models
{
    public class Apply
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Jobtitle")]
        public string Jobtitle { get; set; }

        [Display(Name = "Fullname")]
        public string Fullname { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Degree")]
        public string Degree { get; set; }

        [Display(Name = "Skills")]
        public string Skills { get; set; }



        [Display(Name = "Projects")]
        public string Projects { get; set; }
    }
}