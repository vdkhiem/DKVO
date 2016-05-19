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
    public class ListCategoryController : BaseAdminController
    {
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var Categorys = objBs.categoryBs.GetAll();

            // Implement sorting
            switch (SortBy)
            {
                case "CategoryName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            Categorys = Categorys.OrderBy(p => p.CategoryName).ToList();
                            break;
                        case "Desc":
                            Categorys = Categorys.OrderByDescending(p => p.CategoryName).ToList();
                            break;
                    }
                    break;
                case "CategoryDesc":
                    switch (SortOrder)
                    {
                        case "Asc":
                            Categorys = Categorys.OrderBy(p => p.CategoryDesc).ToList();
                            break;
                        case "Desc":
                            Categorys = Categorys.OrderByDescending(p => p.CategoryDesc).ToList();
                            break;
                    }
                    break;

                // Implement sort default by CategoryTitle
                default:
                    Categorys = Categorys.OrderBy(p => p.CategoryName).ToList();
                    break;
            }

            // Get total pages     
            ViewBag.TotalPages = Math.Ceiling(objBs.categoryBs.GetAll().Count() / 10.0);

            // Implement paging
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            Categorys = Categorys.Skip((page - 1) * 10).Take(10);

            return View(Categorys);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                objBs.categoryBs.Delete(id);
                TempData["Msg"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Deleted Failed: " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}