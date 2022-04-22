using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR_System.Models;
using System.Data.SqlClient;
using System.Data;
using Oracle.DataAccess.Client;

namespace HR_System.Controllers
{
    public class HRController : Controller
    {
        //
        // GET: /HR/
        public ActionResult Employee()
        {
            EmployeeVM emmp=new EmployeeVM();
            emmp._Country = CountryLi();
            emmp._City = CityLi();
            
            return View("Employee",emmp);
        }
        private List<Country> CountryLi()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=User45;Initial Catalog=HR_System;Integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "FillCountry";
            cmd.Connection = con;
          

            con.Open();
            List<Country> FillCountry=new List<Country>();
            SqlDataReader Reader = cmd.ExecuteReader();
            while(Reader.Read())
            {
                Country country = new Country();
                country.ID = Convert.ToInt32(Reader["ID"]);
                country.Name = Reader["Name"].ToString();
                FillCountry.Add(country);

            
            }
            con.Close();
            return FillCountry;









            
        }
        private List<City> CityLi()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=User45;Initial Catalog=HR_System;Integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "FillCity";
            cmd.Connection = con;


            con.Open();
            List<City> Fillcity = new List<City>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                City city = new City();
                city.ID = Convert.ToInt32(reader["ID"]);
                city.Name = reader["Name"].ToString();
                Fillcity.Add(city);


            }
            con.Close();
            return Fillcity;
        }

        public ActionResult Save()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=User45;Initial Catalog=HR_System;Integrated security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertEmployee";
            cmd.Connection = con;

            SqlParameter FName = cmd.Parameters.Add("@FName", SqlDbType.VarChar);
            FName.Direction = ParameterDirection.Input;
            FName.Value = Request.Form["Emp.FirstName"];

            SqlParameter LName = cmd.Parameters.Add("@LName", SqlDbType.VarChar);
            LName.Direction = ParameterDirection.Input;
            LName.Value = Request.Form["Emp.LastName"];

            SqlParameter Phone = cmd.Parameters.Add("@Phone", SqlDbType.Int);
            Phone.Direction = ParameterDirection.Input;
            Phone.Value = Convert.ToInt32(Request.Form["Emp.Phone"]);

            SqlParameter Gender = cmd.Parameters.Add("@Gender", SqlDbType.VarChar);
            Gender.Direction = ParameterDirection.Input;
            Gender.Value = Request.Form["Emp.Gender"];

            SqlParameter Country = cmd.Parameters.Add("@Country", SqlDbType.VarChar);
            Country.Direction = ParameterDirection.Input;
            Country.Value = Request.Form["Emp.Country"];

            SqlParameter City = cmd.Parameters.Add("@City", SqlDbType.VarChar);
            City.Direction = ParameterDirection.Input;
            City.Value = Request.Form["Emp.City"];

            SqlParameter Address = cmd.Parameters.Add("@Address", SqlDbType.VarChar);
            Address.Direction = ParameterDirection.Input;
            Address.Value = Request.Form["Emp.Address"];

            SqlParameter Email = cmd.Parameters.Add("@Email", SqlDbType.VarChar);
            Email.Direction = ParameterDirection.Input;
            Email.Value = Request.Form["Emp.Email"];

            SqlParameter Salary = cmd.Parameters.Add("@Salary", SqlDbType.Int);
            Salary.Direction = ParameterDirection.Input;
            Salary.Value = Convert.ToInt32(Request.Form["Emp.Salary"]);

            SqlParameter ExpectedSalary = cmd.Parameters.Add("@ExpectedSalary", SqlDbType.Int);
            ExpectedSalary.Direction = ParameterDirection.Input;
            ExpectedSalary.Value = Convert.ToInt32(Request.Form["Emp.ExbectedSalary"]);

            SqlParameter HireDate = cmd.Parameters.Add("@HireDate", SqlDbType.Date);
            HireDate.Direction = ParameterDirection.Input;
            HireDate.Value = Convert.ToDateTime(Request.Form["Emp.HireDate"]);

            return View("Employee");


           

        }


        public ActionResult EmployeeList()
        {
            EmployeeVM EmpVM = new EmployeeVM();
            EmpVM._Employee = new List<Employee>();
            return View("EmployeeList", EmpVM);
        }
	}
}