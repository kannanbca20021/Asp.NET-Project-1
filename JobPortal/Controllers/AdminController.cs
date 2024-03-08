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
    public class AdminController : Controller
    {
        /// <summary>
        /// This function is used to get details of contact messages.
        /// </summary>
        public ActionResult GetContact()
        {
            ContactRepository CotRepo = new ContactRepository();
            ModelState.Clear();
            return View(CotRepo.GetContactDetails());

        }

        /// <summary>
        /// This function is used to edit details of contact messages.
        /// </summary>
        public ActionResult EditDetails(int? Id)
        {
            ContactRepository CotRepo = new ContactRepository();
            return View(CotRepo.GetContactDetails().Find(contact => contact.Id == Id));

        }


        [HttpPost]
        public ActionResult EditDetails(int? Id, Contact Contact)
        {
            try
            {
                ContactRepository CotRepo = new ContactRepository();
                CotRepo.EditContactDetails(Contact);
                return RedirectToAction("GetContact");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// This function is used to delete details of contact messages.
        /// </summary>
        public ActionResult DeleteDetails(int Id, Contact Contact)
        {
            try
            {
                ContactRepository CotRepo = new ContactRepository();
                if (CotRepo.DeleteContact(Id))
                {
                    ViewBag.AlertMessage("Details Deleted Successfully");
                }
                return RedirectToAction("GetContact");
            }
            catch
            {
                return View();

            }
        }
        /// <summary>
        /// This function is used to add jobs..
        /// </summary>
        public ActionResult AddJob()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddJob(Job Job)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JobRepository JobRepo = new JobRepository();
                    if (JobRepo.AddJob(Job))
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



        /// <summary>
        /// This function is used to manage jobs.
        /// </summary>
        public ActionResult GetJobDetails()
        {
            JobRepository JobRepo = new JobRepository();
            ModelState.Clear();
            return View(JobRepo.GetJobDetails());

        }

        /// <summary>
        /// This function is used to edit the jobs.
        /// </summary>
        public ActionResult EditJob(int? id)
        {
            JobRepository JobRepo = new JobRepository();
            return View(JobRepo.GetJobDetails().Find(Job => Job.Id == id));

        }


        [HttpPost]
        public ActionResult EditJob(int? id, Job obj)
        {
            try
            {
                JobRepository JobRepo = new JobRepository();
                JobRepo.EditJob(obj);
                return RedirectToAction("GetJobDetails");
            }
            catch
            {
                return View();

            }
        }

        /// <summary>
        /// This function is used to delete the jobs.
        /// </summary>
        public ActionResult DeleteJob(int id, Job obj)
        {
            try
            {
                JobRepository JobRepo = new JobRepository();
                if (JobRepo.DeleteJob(id))
                {
                    ViewBag.AlertMessage("Usert Details Deleted Successfully");
                }
                return RedirectToAction("GetJobDetails");
            }
            catch
            {
                return View();

            }
        }

        /// <summary>
        /// This function is used to get details of applied candidates.
        /// </summary>
        public ActionResult GetAppliedDetails()
        {
            ApplyRepository ApyRepo = new ApplyRepository();
            ModelState.Clear();
            return View(ApyRepo.GetDetails());

        }

        /// <summary>
        /// This function is used to edit applies of candidate.
        /// </summary>
        public ActionResult EditApply(int? Id)
        {
            ApplyRepository ApyRepo = new ApplyRepository();
            return View(ApyRepo.GetDetails().Find(apply => apply.Id == Id));

        }


        [HttpPost]
        public ActionResult EditApply(int? Id, Apply obj)
        {
            try
            {
                ApplyRepository ApyRepo = new ApplyRepository();
                ApyRepo.EditDetails(obj);
                return RedirectToAction("GetDetails");
            }
            catch
            {
                return View();

            }
        }

        /// <summary>
        /// This function is used to delete the applies.
        /// </summary>
        public ActionResult DeleteApply(int Id, Apply obj)
        {
            try
            {
                ApplyRepository ApyRepo = new ApplyRepository();
                if (ApyRepo.DeleteDetails(Id))
                {
                    ViewBag.AlertMessage("User Details Deleted Successfully");
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

