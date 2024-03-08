using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace JobPortal
{
    public class ApplyRepository
    {
            private SqlConnection Con;


            private void connection()
            {


                string constr = ConfigurationManager.ConnectionStrings["GetConn"].ToString();
                Con = new SqlConnection(constr);

            }
            public bool InsertDetail(Apply obj)
            {
                connection();
                SqlCommand com = new SqlCommand("SP_JA", Con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@Jobtitle", obj.Jobtitle);
                com.Parameters.AddWithValue("@Fullname", obj.Fullname);
                com.Parameters.AddWithValue("@Email", obj.Email);
                com.Parameters.AddWithValue("@Phone", obj.Phone);                    
                com.Parameters.AddWithValue("@Degree", obj.Degree);
                com.Parameters.AddWithValue("@Skills", obj.Skills);
                com.Parameters.AddWithValue("@Projects", obj.Projects);
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

            public List<Apply> GetDetails()
            {
                connection();
                List<Apply> Applylist = new List<Apply>();
                SqlCommand com = new SqlCommand("SP_JA", Con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@type", "select");
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                Con.Open();
                da.Fill(dt);
                Con.Close();





                foreach (DataRow dr in dt.Rows)
                Applylist.Add(
                            new Apply
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Jobtitle = Convert.ToString(dr["Jobtitle"]),
                                Fullname = Convert.ToString(dr["Fullname"]),
                                Phone = Convert.ToString(dr["Phone"]),
                                Email = Convert.ToString(dr["Email"]),
                                Degree = Convert.ToString(dr["Degree"]),
                                Skills = Convert.ToString(dr["Skills"]),
                                Projects = Convert.ToString(dr["Projects"]),
                            }

                                );
                return Applylist;
            }


            public bool EditDetails(Apply obj)
            {
                connection();
                SqlCommand com = new SqlCommand("SP_JA", Con);
                com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Jobtitle", obj.Jobtitle);
            com.Parameters.AddWithValue("@Fullname", obj.Fullname);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Phone", obj.Phone);
            com.Parameters.AddWithValue("@Degree", obj.Degree);
            com.Parameters.AddWithValue("@Skills", obj.Skills);
            com.Parameters.AddWithValue("@Projects", obj.Projects);
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
                SqlCommand com = new SqlCommand("SP_JA", Con);
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