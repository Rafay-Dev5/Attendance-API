using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project1.Models;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;

namespace Project1.Controllers
{
    [ApiController]
    public class TeachController : System.Web.Http.ApiController
    {
        private IPT_ProjEntities db = new IPT_ProjEntities();

        // GET: Teach
        public IEnumerable<Teacher> Get()
        {
            var teachers = db.Teachers.ToList();

            foreach (var teacher in teachers)
            {
                Console.WriteLine(teacher);
            }

            //JsonConvert.SerializeObject(teachers, Formatting.Indented);
            //var json = JsonSerializer.Serialize(teachers);
            
            return teachers;
        }
    }
}