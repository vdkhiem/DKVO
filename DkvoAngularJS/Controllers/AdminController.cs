using BLL;
using BOL;
using Framework.Shared;
using Newtonsoft.Json;
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
            try
            {   
                var items = objBs.menuBs.GetAppMenuAll().OrderBy(x => x.SortOrder).ToList();
                var list = JsonConvert.SerializeObject(items,
                Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });

                return Content(list, "application/json");
                //return Json(items, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex.Message, ex);
                throw ex;
            }
        }

        public ActionResult GetMenusByAppId(string appId)
        {
            var items = objBs.menuBs.GetAppMenuAll().OrderBy(x => x.SortOrder).ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMenus()
        {
            IEnumerable<Menu> items;
            try
            {
                items = objBs.menuBs.GetAll().ToList();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex.Message, ex);
                throw ex;
            }            

            var list = JsonConvert.SerializeObject(items,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });

            return Content(list, "application/json");
        }
    }
}