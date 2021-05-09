using ModelLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPILayer.Controllers
{
    public class EmployeeController : ApiController
    {
        List<Employee> employees;

        public EmployeeController()
        {
            employees = new List<Employee>();
            //employees.Add(new Employee { ID = 1, Name = "John", ContactNumber = 99999999, Address = "Test Address1" });
            //employees.Add(new Employee { ID = 2, Name = "Anna", ContactNumber = 11111111, Address = "Test Address2" });
        }
        // GET api/employee
        [Filters.CustomAuthentication]
        public IEnumerable<Employee> Get()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString);
            string command = "select * from Employee";
            SqlDataAdapter da = new SqlDataAdapter(command, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                employees.Add(new Employee
                {
                    ID = (int)dr["ID"],
                    Name = (string)dr["FirstName"] + " " + dr["LastName"].ToString(),
                    ContactNumber = Convert.ToInt64(dr["ContactNumber"]),
                    Address = (string)dr["Address"]
                });
            }
            cn.Close();
            return employees;
        }

        // GET api/employee/1
        [Filters.CustomAuthentication]
        public Employee Get(int id)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString);
            string command = "select * from Employee where id = " + id;
            SqlDataAdapter da = new SqlDataAdapter(command, cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                employees.Add(new Employee
                {
                    ID = (int)dr["ID"],
                    Name = (string)dr["FirstName"] + " " + dr["LastName"].ToString(),
                    ContactNumber = Convert.ToInt64(dr["ContactNumber"]),
                    Address = (string)dr["Address"]
                });
            }
            cn.Close();
            return employees.FirstOrDefault(x => x.ID.Equals(id));
        }
    }
}