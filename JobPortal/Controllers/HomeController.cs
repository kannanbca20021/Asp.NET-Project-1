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
using JobPortal.Common;

namespace JobPortal.Controllers
{
    /// <summary>
    /// This function is used to create Home page for new users.
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

        /// <summary>
        /// This function is used to create About us page for new users.
        /// </summary> 
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// This function is used to create Contact page for new users.
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
        /// This function is used to create Login page for users.
        /// </summary>

        private SqlConnection con;
        private string Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["GetConn"].ToString();
            con = new SqlConnection(constr);


            return constr;
        }
        public ActionResult Signin()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Signin(Signin Signup)
            
        {

            Connection();
            SqlCommand sqlcomm = new SqlCommand("UserLogin", con);
            sqlcomm.CommandType = CommandType.StoredProcedure;

            con.Open();
            sqlcomm.Parameters.AddWithValue("@Email", Signup.Email);
            sqlcomm.Parameters.AddWithValue("@Password", Signup.Password);

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            if (sdr.Read())
            {
                Password EncryptData = new Password();



                if (Signup.Email == "admin@gmail.com" || Signup.Password == "123")
                {
                    
                    FormsAuthentication.SetAuthCookie(Signup.Email, true);
                    Session["Email"] = Signup.Email.ToString();
                    FormsAuthentication.SetAuthCookie(Signup.Password, true);
                    Session["Password"] = EncryptData.Encode(Signup.Password).ToString();
                    return RedirectToAction("AddJob", "Admin");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(Signup.Email, true);
                    Session["Email"] = Signup.Email.ToString();
                    FormsAuthentication.SetAuthCookie(Signup.Password, true);
                    Session["Password"] = EncryptData.Encode(Signup.Password).ToString();
                    return RedirectToAction("Home", "Registration");
                }
            }

            else
            {
                ViewBag.Message = "login failed!!";
            }
            con.Close();
            ViewBag.Message = "login successfully!";
            return View();

        }

        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("Signin", "Home");
        }
    }
}