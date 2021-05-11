using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLayer
{
    public class EmployeeManager
    {
        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> employees = null;
            using (MVCWebAPIAppEntities entities = new MVCWebAPIAppEntities())
            {
                employees = entities.Employees.AsEnumerable().Select(x => new Employee
                {
                    ID = x.ID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ContactNumber = x.ContactNumber,
                    Address = x.Address
                }).ToList();

            }
            return employees;
        }

        public IEnumerable<Employee> GetEmployeeByID(int id)
        {
            List<Employee> employees = null;
            using (MVCWebAPIAppEntities entities = new MVCWebAPIAppEntities())
            {
                employees = entities.Employees.AsEnumerable().Where(x => x.ID == id).Select(x => new Employee
                {
                    ID = x.ID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ContactNumber = x.ContactNumber,
                    Address = x.Address
                }).ToList();

            }
            return employees;
        }
    }
}
