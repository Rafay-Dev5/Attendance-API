using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project1.Models;
using static System.Collections.Specialized.BitVector32;

namespace Project1.Controllers
{
    [ApiController]
    public class DeptController : System.Web.Http.ApiController
    {
        private IPT_ProjEntities db = new IPT_ProjEntities();

        // GET: Teach
        public IEnumerable<Department> GetDepartments()
        {
            var depts= db.Departments.ToList();
            JsonConvert.SerializeObject(depts, Formatting.Indented);
            return depts;
        }
    }
}