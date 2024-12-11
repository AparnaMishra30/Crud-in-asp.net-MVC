using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using mvclearn.Models;

namespace mvclearn
{
    public class DBrun
    {
         static string con = "Initial Catalog=Student; Data Source=occweb05; User ID=sa; Password=odpserver550810998@";
        internal static void Create(Model model)
        {
            string x = model.personname;
            int y = model.personage;
            SqlConnection conn = new SqlConnection(con);
            string query = "insert into Employee (name) values('" + x + "')";
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
        }

        internal static void Update(Model model)
        {
            string x = model.personname;
            int y = model.personage;
            int z = model.personid;
            SqlConnection conn = new SqlConnection(con);
            string query = "update Employee set name='" + x + "' where id ="+ z +"";
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataTable dd = new DataTable();
            ad.Fill(dd);
        }


        public List<Model> FetchEmployees()
        {
            List<Model> employees = new List<Model>();
                    SqlConnection conn = new SqlConnection(con);
                 SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM Employee", conn);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
        
                    foreach (DataRow row in dt.Rows)
                    {
                        Model employee = new Model
                        {

                            personid = Convert.ToInt32(row["id"]),
                            personname = row["name"].ToString()
                        };

                        employees.Add(employee);
                    }
            return employees; 
        }

        internal static void deleterow(int id)
        {
            int ind = Convert.ToInt32(id);
            SqlConnection sq = new SqlConnection(con);
            sq.Open();
            SqlCommand cmd = new SqlCommand("delete Employee where id =" + ind + "", sq);
            cmd.ExecuteScalar();
            sq.Close();
        }
    }
}