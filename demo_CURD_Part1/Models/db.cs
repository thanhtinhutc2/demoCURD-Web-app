using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using demo_CURD_Part1.Models;

namespace demo_CURD_Part1.Models
{
    public class db
    {
        SqlConnection conn = new SqlConnection(@"Data Source=F51N30SU\SQLEXPRESS;Initial Catalog=DemoCURD1;Integrated Security=True");


        //Select data
        public DataSet Empget(Employee emp, out string msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Employee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                cmd.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@STATE", emp.State);
                cmd.Parameters.AddWithValue("@Country", emp.Country);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@flag", emp.flag);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "OK";
                return ds;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return ds;
            }
        }


        //Insert and update
        public string Empdm1(Employee emp, out string msg)
        {
            msg = "";
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Employee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                cmd.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@STATE", emp.State);
                cmd.Parameters.AddWithValue("@Country", emp.Country);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@flag", emp.flag);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                msg = "OK";
                return msg;
            }
            catch (Exception ex)
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                msg = ex.Message;
                return msg;
            }
        }
    }

    
}
