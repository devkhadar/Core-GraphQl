using Demo.IService;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Service
{
    public class EmployeeService : IEmployee
    {
        public IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>() {
            new Employee(){Id=1,Name="Khadar",Salary=100000}
            };
        }
    }
}
