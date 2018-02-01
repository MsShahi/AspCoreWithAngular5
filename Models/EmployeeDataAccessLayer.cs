using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AspCorewithAngular5.Models
{
    public class EmployeeDataAccessLayer
    {
        string connectionString = "Data Source=172.18.14.122;Initial Catalog=AngularDb;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=brain;";

        public IEnumerable<Employees> GetAllEmployees()
        {
            try
            {
                List<Employees> emplist = new List<Employees>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        Employees emp = new Employees();
                        emp.ID = Convert.ToInt32(rdr["EmployeeId"]);
                        emp.Name = rdr["Name"].ToString();
                        emp.Gender = rdr["Gender"].ToString();
                        emp.Department = rdr["Department"].ToString();
                        emp.City = rdr["City"].ToString();
                        emplist.Add(emp);
                    }
                    return emplist;
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
       

        public int AddEmployee(Employees emp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name",emp.Name);
                    cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@Department", emp.Department);
                    cmd.Parameters.AddWithValue("@City", emp.City);
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                    return 1;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateEmployee(Employees emp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {                   
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeId",emp.ID);
                    cmd.Parameters.AddWithValue("@Name", emp.Name);
                    cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@Department", emp.Department);
                    cmd.Parameters.AddWithValue("@City", emp.City);

                    con.Open();

                    cmd.ExecuteNonQuery();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteEmployee(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeId", id);
                    
                    con.Open();

                    cmd.ExecuteNonQuery();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employees GetEmployeeDetail(int id)
        {
            try
            {
              Employees emp = new Employees();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetEmployeeDetail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeId", id);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {                        
                        emp.ID = Convert.ToInt32(rdr["EmployeeId"]);
                        emp.Name = rdr["Name"].ToString();
                        emp.Gender = rdr["Gender"].ToString();
                        emp.Department = rdr["Department"].ToString();
                        emp.City = rdr["City"].ToString();
                       
                    }
                    return emp;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
