using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHub.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class CategoryController : BaseAdminController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Category objCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objBs.categoryBs.Insert(objCategory);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Created Failed: " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}