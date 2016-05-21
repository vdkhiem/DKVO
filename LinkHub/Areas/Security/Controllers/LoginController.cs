using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LinkHub.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseSecurityController
    {
        // GET: Security/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(tbl_User user)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    if (Membership.ValidateUser(user.UserEmail, user.Password))
                    {
                        FormsAuthentication.SetAuthCookie(user.UserEmail, false); //Remember me
                        return RedirectToAction("Index", "Home", new { area = "Common" });
                    }
                    else
                    {
                        TempData["Msg"] = "Login Failed";
                        return RedirectToAction("Index");
                    }
                //}

                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Login Failed: " + ex.Message;
                return RedirectToAction("Index");
            }
                    
        }

        // GET: Security/SignOut
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home", new {area = "Common"});
        }
    }
}