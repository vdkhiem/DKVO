using BLL;
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
    public class DepartmentsController : Controller
    {
       // private MyOrgEntities db = new MyOrgEntities();

        protected AdminBs objBs;
        public DepartmentsController()
        {
            objBs = new AdminBs();
        }

        // GET: Departments
        public ActionResult GetDepartments()
        {
            return Json(objBs.menuBs.GetAll().ToList(), JsonRequestBehavior.AllowGet); 
        }
    }
}
