using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHub.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ApproveURLsController : BaseAdminController
    {
        // GET: Admin/ApproveURLs
        public ActionResult Index(string status)
        {
            ViewBag.Status = (status == null ? "P" : status);  //Store to viewbag to bold the link
            
            if (status == null)
            {
                var urls = objBs.urlBs.GetAll().Where(p => p.IsApproved == "P").ToList();
                return View(urls);
            }
            else
            {
                var urls = objBs.urlBs.GetAll().Where(p => p.IsApproved == status).ToList();
                return View(urls);
            }
        }

        public ActionResult Approve(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbl_Url objUrl = objBs.urlBs.GetByID(int.Parse(id));
                    objUrl.IsApproved = "A";
                    objBs.urlBs.Update(objUrl);
                    TempData["Msg"] = "Approved Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Approved Failed: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Reject(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbl_Url objUrl = objBs.urlBs.GetByID(int.Parse(id));
                    objUrl.IsApproved = "R";
                    objBs.urlBs.Update(objUrl);
                    TempData["Msg"] = "Rejected Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Rejected Failed: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

    }
}