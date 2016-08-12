using BLL;
using BOL;
using DkvoApi.DataTransferObjects;
using Framework.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DkvoApi.Controllers
{
    public class PersonController : ApiController
    {
        protected PersonBs objBs;
        public PersonController()
        {
            objBs = new PersonBs();
        }

        public IHttpActionResult Get()
        {
            var result = objBs.GetAll();

            var response = result.To<PersonDto>();

            return Ok(response);
        }

        public IHttpActionResult GetPersonById(int id)
        {
            var result = objBs.GetByID(id);

            if (result !=  null && result.Id <= 0)
            {
                return NotFound();
            }

            var response = result.To<PersonDto>();

            return Ok(response);
        }

        public IHttpActionResult Post([FromBody]Person person, int id)
        {
            person.Id = id;
            objBs.Update(person);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
