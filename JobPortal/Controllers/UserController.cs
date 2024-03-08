using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using JobPortal.Models;
using JobPortal.Repository;
using System.Drawing;
using System.Configuration;

namespace JobPortal.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// This function is used to create about us for users.
        /// </summary>

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// This function is used to create contact us page for user.
        /// </summary>

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ContactRepository CotRepo = new ContactRepository();

                    if (CotRepo.AddContact(contact))
                    {
                        ViewBag.Message = "Details Added Successfully";
                    }
                }
                return RedirectToAction("About");

            }
            catch
            {
                return View();

            }
        }
        /// <summary>
        /// This function is used to get details of available jobs.
        /// </summary>

        public ActionResult GetJobDetails()
        {
            JobRepository JobRepo = new JobRepository();
            ModelState.Clear();
            return View(JobRepo.GetJobDetails());

        }

        /// <summary>
        /// This function is used to apply for available jobs.
        /// </summary>
        public ActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Apply(Apply apply)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ApplyRepository ApyRepo = new ApplyRepository();

                    if (ApyRepo.InsertDetail(apply))
                    {
                        ViewBag.Message = "Details Added Successfully";
                    }
                }
                return RedirectToAction("GetJobDetails");

            }
            catch
            {
                return View();

            }
        }

    }
}
