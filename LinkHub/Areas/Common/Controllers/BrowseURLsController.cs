using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHub.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class BrowseURLsController : Controller
    {
        private UrlBs objBs;
        public BrowseURLsController()
        {
            objBs = new UrlBs();
        }

        // GET: Common/BrowseURLs
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var urls = objBs.GetAll().Where(p => p.IsApproved == "A");

            // Implement sorting
            switch (SortBy)
            {
                case "Title":
                    switch (SortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(p => p.UrlTitle).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(p => p.UrlTitle).ToList();
                            break;
                    }
                    break;
                case "Url":
                    switch (SortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(p => p.Url).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(p => p.Url).ToList();
                            break;
                    }
                    break;
                case "UrlDesc":
                    switch (SortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(p => p.UrlDesc).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(p => p.UrlDesc).ToList();
                            break;
                    }
                    break;
                case "Category":
                    switch (SortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(p => p.tbl_Category.CategoryName).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(p => p.tbl_Category.CategoryName).ToList();
                            break;
                    }
                    break;

                // Implement sort default by UrlTitle
                default:
                    urls = urls.OrderBy(p => p.UrlTitle).ToList();
                    break;
            }

            // Get total pages     
            ViewBag.TotalPages = Math.Ceiling(objBs.GetAll().Where(p => p.IsApproved == "A").Count() / 10.0);

            // Implement paging
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            urls = urls.Skip((page - 1) * 10).Take(10);
            
            return View(urls);
        }
    }
}