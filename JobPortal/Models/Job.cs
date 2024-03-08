using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace JobPortal.Models
{
    public class Job
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Company name")]
        public string C_Name { get; set; }

        [Display(Name = "Job name")]
        public string J_Name { get; set; }

        [Display(Name = "Job field")]
        public string J_Field { get; set; }

        [Display(Name = "Vacancy")]
        public string Vacancy { get; set; }

        [Display(Name = "Job description")]
        public string J_Description { get; set; }


        [Display(Name = "Salary")]
        public string Salary { get; set; }

        [Display(Name = "Locaion")]
        public string Locaion { get; set; }
    }
}