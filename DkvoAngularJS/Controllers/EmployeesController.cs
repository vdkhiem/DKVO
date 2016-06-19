using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using RoutingEg.Models;

namespace RoutingEg.Controllers
{
    public class EmployeesController : Controller
    {
        //private MyOrgEntities db = new MyOrgEntities();

        // GET: Employees
        public ActionResult GetEmployees()
        {
            return Json("",JsonRequestBehavior.AllowGet);
        }
      
    }
}
