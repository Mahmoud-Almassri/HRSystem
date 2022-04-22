using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_System.Models
{
    public class Employee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Phone { get; set; }

        public int Gender { get; set; }

        public int Country { get; set; }

        public int City { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public double Salary { get; set; }

        public double ExbectedSalary { get; set; }

        public DateTime HireDate { get; set; }


    }
}