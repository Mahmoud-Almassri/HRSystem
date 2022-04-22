using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_System.Models
{
    public class EmployeeVM
    {
        public Employee Emp;
        public List<Employee> _Employee;
        public List<City> _City;
        public List<Country> _Country;
        
    }
}