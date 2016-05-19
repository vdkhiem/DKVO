using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHub.Areas.Security.Controllers
{
    public class BaseSecurityController : Controller
    {
        protected SecurityBs objBs { get; set; }
        public BaseSecurityController()
        {
            objBs = new SecurityBs();
        }
    }
}