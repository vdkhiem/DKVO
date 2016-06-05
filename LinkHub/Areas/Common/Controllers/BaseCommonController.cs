using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHub.Areas.Common.Controllers
{
    public class BaseCommonController : Controller
    {
        protected CommonBs objBs;
        public BaseCommonController()
        {
            objBs = new CommonBs();
        }
    }
}