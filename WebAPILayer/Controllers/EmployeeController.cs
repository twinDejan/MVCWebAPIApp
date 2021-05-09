using ModelLayer;
using System;
using System.Collections.Generic;
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
            employees.Add(new Employee { ID = 1, Name = "John", ContactNumber = 99999999, Address = "Test Address1" });
            employees.Add(new Employee { ID = 2, Name = "Anna", ContactNumber = 11111111, Address = "Test Address2" });
        }
        // GET api/employee
        [Filters.CustomAuthentication]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }

        // GET api/employee/1
        [Filters.CustomAuthentication]
        public Employee Get(int id)
        {
            return employees.FirstOrDefault(x => x.ID.Equals(id));
        }
    }
}