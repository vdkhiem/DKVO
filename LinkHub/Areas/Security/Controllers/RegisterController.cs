using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHub.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class RegisterController : BaseSecurityController
    {
        // GET: Security/Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_User objUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objUser.Role = "U";
                    objBs.userBs.Insert(objUser);
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