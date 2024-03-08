using JobPortal.Models;
using JobPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortal.Controllers
{
    public class RegistrationController : Controller
    {
        /// <summary>
        /// This function is used to add homepage for user.
        /// </summary>
        public ActionResult Home()
        {
            return View();
        }


        /// <summary>
        /// This function is used to create registration page for user.
        /// </summary>
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Registration registration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    RegistrationRepository RegRepo = new RegistrationRepository();

                    if (RegRepo.AddDetails(registration))
                    {
                        ViewBag.Message = "Successfully Registered" ;
                    }
                }
                return RedirectToAction("Home");

            }
            catch
            {
                return View();

            }
        }


        /// <summary>
        /// This function is used to get details of registered users.
        /// </summary>

        public ActionResult GetUserDetails()
        {
            RegistrationRepository RegRepo = new RegistrationRepository();
            ModelState.Clear();
            return View(RegRepo.GetDetails());

        }

        /// <summary>
        /// This function is used to edit registered users.
        /// </summary>

        public ActionResult EditUserDetails(int? Id)
        {
            RegistrationRepository RegRepo = new RegistrationRepository();
            return View(RegRepo.GetDetails().Find(registration => registration.Id == Id));

        }


        [HttpPost]
        public ActionResult EditUserDetails(int? Id, Registration obj)
        {
            try
            {
                RegistrationRepository RegRepo = new RegistrationRepository();
                RegRepo.EditDetails(obj);
                return RedirectToAction("GetUserDetails");
            }
            catch
            {
                return View();

            }
        }

        /// <summary>
        /// This function is used to delete registered users.
        /// </summary>
        public ActionResult DeleteUser(int Id, Registration obj)
        {
            try
            {
                RegistrationRepository RegRepo = new RegistrationRepository();
                if (RegRepo.DeleteDetails(Id))
                {
                    ViewBag.AlertMessage("Usert Details Deleted Successfully");
                }
                return RedirectToAction("GetDetails");
            }
            catch
            {
                return View();

            }
        }
    }
}
