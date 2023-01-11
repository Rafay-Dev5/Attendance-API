using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project1.Controllers
{
    public class ValuesController : ApiController
    {
        private IPT_ProjEntities db = new IPT_ProjEntities();
        // GET api/<controller>
        public IEnumerable<Teacher> Get()
        {
            var teachers = db.Teachers.ToList();

            return teachers;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}