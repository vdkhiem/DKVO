using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHub.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class QuickURLSubmitController : BaseCommonController
    {
        // GET: Common/QuickURLSubmit
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetAll(), "CategoryId", "CategoryName");
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(QuickURLSubmitModel myQuickUrl)
        {
            try
            {
                //Bypass validations for this particular request
                ModelState.Remove("MyUser.Password");
                ModelState.Remove("MyUser.ConfirmPassword");
                ModelState.Remove("MyUrl.UrlDesc");

                if (ModelState.IsValid)
                {
                    objBs.InsertQuickURL(myQuickUrl);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetAll(), "CategoryId", "CategoryName");
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