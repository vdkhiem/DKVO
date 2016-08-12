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
    public class PersonController : Controller
    {
        protected PersonBs objBs;
        public PersonController()
        {
            objBs = new PersonBs();
        }

        // GET: Person
        public ActionResult GetPersons()
        {
            IEnumerable<Person> items;
            try
            {
                items = objBs.GetAll().ToList();
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

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Person person)
        {
            objBs.Insert(person);
            var list = JsonConvert.SerializeObject(person,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });

            return Content(list, "application/json");
        }
    }
}