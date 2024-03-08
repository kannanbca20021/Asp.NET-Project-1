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
using JobPortal.Repository;

namespace JobPortal.Repository
{
    public class JobRepository
    {
        private SqlConnection Con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["GetConn"].ToString();
            Con = new SqlConnection(constr);

        }
        public bool AddJob(Job Job)
        {
            connection();
            SqlCommand com = new SqlCommand("SP_Job", Con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@C_Name", Job.C_Name);
            com.Parameters.AddWithValue("@J_Name", Job.J_Name);
            com.Parameters.AddWithValue("@J_Field", Job.J_Field);
            com.Parameters.AddWithValue("@Vacancy", Job.Vacancy);
            com.Parameters.AddWithValue("@J_Description", Job.J_Description);
            com.Parameters.AddWithValue("@Salary", Job.Salary);
            com.Parameters.AddWithValue("@Locaion", Job.Locaion);
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

        public List<Job> GetJobDetails()
        {
            connection();
            List<Job> Joblist = new List<Job>();
            SqlCommand com = new SqlCommand("SP_Job", Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@type", "select");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            Con.Open();
            da.Fill(dt);
            Con.Close();





            foreach (DataRow dr in dt.Rows)
                Joblist.Add(
                        new Job
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            C_Name = Convert.ToString(dr["C_Name"]),
                            J_Name = Convert.ToString(dr["J_Name"]),
                            J_Field = Convert.ToString(dr["J_Field"]),
                            Vacancy = Convert.ToString(dr["Vacancy"]),
                            J_Description = Convert.ToString(dr["J_Description"]),
                            Salary = Convert.ToString(dr["Salary"]),
                            Locaion = Convert.ToString(dr["Locaion"]),
                        }

                            );
            return Joblist;
        }


        public bool EditJob(Job Job)
        {
            connection();
            SqlCommand com = new SqlCommand("SP_Job", Con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@C_Name", Job.C_Name);
            com.Parameters.AddWithValue("@J_Name", Job.J_Name);
            com.Parameters.AddWithValue("@J_Field", Job.J_Field);
            com.Parameters.AddWithValue("@Vacancy", Job.Vacancy);
            com.Parameters.AddWithValue("@J_Description", Job.J_Description);
            com.Parameters.AddWithValue("@Salary", Job.Salary);
            com.Parameters.AddWithValue("@Locaion", Job.Locaion);
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

        public bool DeleteJob(int id)
        {
            connection();
            SqlCommand com = new SqlCommand("SP_Job", Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("Id", id);
            com.Parameters.AddWithValue("@type", "delete");


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
    }

}
