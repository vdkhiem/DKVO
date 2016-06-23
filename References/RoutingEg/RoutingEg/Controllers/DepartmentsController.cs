using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RoutingEg.Models;

namespace RoutingEg.Controllers
{
    public class DepartmentsController : Controller
    {
        private MyOrgEntities db = new MyOrgEntities();

        // GET: Departments
        public ActionResult GetDepartments()
        {
            return Json(db.Departments.ToList(),JsonRequestBehavior.AllowGet);
        }
    }
}
