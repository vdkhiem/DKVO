using BLL;
using BOL;
using Framework.Shared;
using Microsoft.Owin.Security;
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

        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                objBs.RegisterUser(user.Email, user.Password);
            }
            catch (Exception ex)
            {
                user.ErrorMessage = ex.Message;
            }

            string list = Jsonreturn(user);

            return Content(list, "application/json");
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var userIdentity = objBs.SignIn(user.Email, user.Password);
            if (userIdentity != null)
            {
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                user.IsSignedIn = true;
            }
            else
            {
                user.IsSignedIn = false;
            }

            string list = Jsonreturn(user);

            return Content(list, "application/json");
        }

        [HttpPost]
        public ActionResult SignOut()
        {
            User user = null;
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut(new AuthenticationProperties() { IsPersistent = false });

            string list = Jsonreturn(user);

            return Content(list, "application/json");
        }

        #region Helper

        /// <summary>
        /// Return json for ActionResult
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private static string Jsonreturn(User user)
        {
            return JsonConvert.SerializeObject(user,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }

        #endregion
    }

    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsSignedIn { get; set; }
        public string ErrorMessage { get; set; }
    }
}