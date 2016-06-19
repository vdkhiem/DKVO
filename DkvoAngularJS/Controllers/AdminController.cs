using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DkvoAngularJS.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        protected AdminBs objBs;
        public AdminController()
        {
            objBs = new AdminBs();
        }

        public ActionResult GetAppMenus()
        {
            var items = objBs.menuBs.GetAppMenuAll().OrderBy(x => x.SortOrder).ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMenusByAppId(string appId)
        {
            var items = objBs.menuBs.GetAppMenuAll().OrderBy(x => x.SortOrder).ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMenus()
        {
            return Json(objBs.menuBs.GetAll().ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}