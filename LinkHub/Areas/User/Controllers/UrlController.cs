using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHub.Areas.User.Controllers
{
    [Authorize(Roles = "A,U")]
    public class UrlController : Controller
    {
        private UrlBs objBs;
        private CategoryBs objCatBs;
        private UserBs objUserBs;

        public UrlController()
        {
            objBs = new UrlBs();
            objCatBs = new CategoryBs();
            objUserBs = new UserBs();
        }

        // GET: User/Url
        public ActionResult Index()
        {   
            ViewBag.CategoryId = new SelectList(objCatBs.GetAll(), "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(objUserBs.GetAll(), "UserId", "UserEmail");
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Url objUrl)
        {
            {
                try
                {
                    objUrl.IsApproved = "P";
                    objUrl.UserId = objUserBs.GetAll().Where(p => p.UserEmail == User.Identity.Name).FirstOrDefault().UserId;

                    if (ModelState.IsValid)
                    {
                        objBs.Insert(objUrl);
                        TempData["Msg"] = "Created Successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.CategoryId = new SelectList(objCatBs.GetAll().ToList(), "CategoryId", "CategoryName");
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
}