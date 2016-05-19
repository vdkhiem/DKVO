using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHub.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ListUserController : BaseAdminController
    {
        // GET: Admin/ListUser
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var Users = objBs.userBs.GetAll();

            // Implement sorting
            switch (SortBy)
            {
                case "UserEmail":
                    switch (SortOrder)
                    {
                        case "Asc":
                            Users = Users.OrderBy(p => p.UserEmail).ToList();
                            break;
                        case "Desc":
                            Users = Users.OrderByDescending(p => p.UserEmail).ToList();
                            break;
                    }
                    break;
                case "Password":
                    switch (SortOrder)
                    {
                        case "Asc":
                            Users = Users.OrderBy(p => p.Password).ToList();
                            break;
                        case "Desc":
                            Users = Users.OrderByDescending(p => p.Password).ToList();
                            break;
                    }
                    break;
                case "Role":
                    switch (SortOrder)
                    {
                        case "Asc":
                            Users = Users.OrderBy(p => p.Role).ToList();
                            break;
                        case "Desc":
                            Users = Users.OrderByDescending(p => p.Role).ToList();
                            break;
                    }
                    break;

                // Implement sort default by UserTitle
                default:
                    Users = Users.OrderBy(p => p.UserEmail).ToList();
                    break;
            }

            // Get total pages     
            ViewBag.TotalPages = Math.Ceiling(objBs.userBs.GetAll().Count() / 10.0);

            // Implement paging
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            Users = Users.Skip((page - 1) * 10).Take(10);

            return View(Users);
        }
    }
}