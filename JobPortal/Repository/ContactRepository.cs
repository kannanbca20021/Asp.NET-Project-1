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
    public class ContactRepository
        {
            private SqlConnection Con;


            private void connection()
            {


                string constr = ConfigurationManager.ConnectionStrings["GetConn"].ToString();
                Con = new SqlConnection(constr);

            }
            public bool AddContact(Contact Contact)
            {
                connection();
                SqlCommand com = new SqlCommand("SP_CP", Con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@Name", Contact.Name);
                com.Parameters.AddWithValue("@Email", Contact.Email);
                com.Parameters.AddWithValue("@Message", Contact.Message);
                com.Parameters.AddWithValue("@Status", Contact.Status);
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

            public List<Contact> GetContactDetails()
            {
                connection();
                List<Contact> Contactlist = new List<Contact>();
                SqlCommand com = new SqlCommand("SP_CP", Con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@type", "select");
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                Con.Open();
                da.Fill(dt);
                Con.Close();





                foreach (DataRow dr in dt.Rows)
                Contactlist.Add(
                            new Contact
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Name = Convert.ToString(dr["Name"]),
                                Email = Convert.ToString(dr["Email"]),
                                Message = Convert.ToString(dr["Message"]),
                                Status = Convert.ToString(dr["Status"]),
                            }

                                );
                return Contactlist;
            }


            public bool EditContactDetails(Contact Contact)
            {
                connection();
                SqlCommand com = new SqlCommand("SP_CP", Con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Contact.Id);
            com.Parameters.AddWithValue("@Name", Contact.Name);
            com.Parameters.AddWithValue("@Email", Contact.Email);
            com.Parameters.AddWithValue("@Message", Contact.Message);
            com.Parameters.AddWithValue("@Status", Contact.Status);
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

            public bool DeleteContact(int Id)
            {
                connection();
                SqlCommand com = new SqlCommand("SP_CP", Con);
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
