using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR_System.Models;
namespace HR_System.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/
        public ActionResult Department()
        {
            return View("Department");
        }
        public ActionResult DepartmentList()
        {
            DepartmentVM deptvm = new DepartmentVM();
            deptvm._Department = new List<Department>();
            return View("DepartmentList",deptvm);
        }
	}
}