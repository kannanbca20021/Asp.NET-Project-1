using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;
using Microsoft.Win32;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Drawing;



namespace JobPortal.Repository
{
    public class RegistrationRepository
    {
        private SqlConnection Con;


        private void connection()
        {


            string constr = ConfigurationManager.ConnectionStrings["GetConn"].ToString();
            Con = new SqlConnection(constr);

        }
        public bool AddDetails(Registration Signup)
        {
            connection();
            SqlCommand com = new SqlCommand("spregistration", Con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Firstname", Signup.Firstname);
            com.Parameters.AddWithValue("@Lastname", Signup.Lastname);
            com.Parameters.AddWithValue("@Dateofbirth", Signup.Dateofbirth);
            com.Parameters.AddWithValue("@Gender", Signup.Gender);
            com.Parameters.AddWithValue("@Email", Signup.Email);
            com.Parameters.AddWithValue("@Phonenumber", Signup.Phonenumber);
            com.Parameters.AddWithValue("@State", Signup.State);
            com.Parameters.AddWithValue("@City", Signup.City);         
            com.Parameters.AddWithValue("@Password", Signup.Password);
            com.Parameters.AddWithValue("@Confirmpassword", Signup.Confirmpassword);
            com.Parameters.AddWithValue("@type", "insert");

            Con.Open();
            int i = com.ExecuteNonQuery();
            Con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Registration> GetDetails()
        {
            connection();
            List<Registration> Registrationlist = new List<Registration>();
            SqlCommand com = new SqlCommand("spregistration", Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@type", "select");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            Con.Open();
            da.Fill(dt);
            Con.Close();





            foreach (DataRow dr in dt.Rows)
                Registrationlist.Add(
                        new Registration
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Firstname = Convert.ToString(dr["Firstname"]),
                            Lastname = Convert.ToString(dr["Lastname"]),
                            Dateofbirth = Convert.ToString(dr["Dateofbirth"]),
                            Gender = Convert.ToString(dr["Gender"]),
                            Phonenumber = Convert.ToString(dr["Phonenumber"]),
                            Email = Convert.ToString(dr["Email"]),
                            State = Convert.ToString(dr["State"]),
                            City = Convert.ToString(dr["City"]),
                           
                            Password = Convert.ToString(dr["Password"]),
                            Confirmpassword = Convert.ToString(dr["Confirmpassword"])
                        }

                            );
            return Registrationlist;
        }


        public bool EditDetails(Registration Signup)
        {
            connection();
            SqlCommand com = new SqlCommand("spregistration", Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", Signup.Id);
            com.Parameters.AddWithValue("@Firstname", Signup.Firstname);
            com.Parameters.AddWithValue("@Lastname", Signup.Lastname);
            com.Parameters.AddWithValue("@Dateofbirth", Signup.Dateofbirth);
            com.Parameters.AddWithValue("@Gender", Signup.Gender);
            com.Parameters.AddWithValue("@Email", Signup.Email);
            com.Parameters.AddWithValue("@Phonenumber", Signup.Phonenumber);
            com.Parameters.AddWithValue("@State", Signup.State);
            com.Parameters.AddWithValue("@City", Signup.City);
            com.Parameters.AddWithValue("@Password", Signup.Password);
            com.Parameters.AddWithValue("@Confirmpassword", Signup.Confirmpassword);
            com.Parameters.AddWithValue("@type", "update");

            Con.Open();
            int i = com.ExecuteNonQuery();
            Con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteDetails(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("spregistration", Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("Id", Id);
            com.Parameters.AddWithValue("@type", "delete");


            Con.Open();
            int i = com.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}