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

namespace Project1.Controllers
{
    [ApiController]
    public class SecController : System.Web.Http.ApiController
    {
        private IPT_ProjEntities db = new IPT_ProjEntities();

        // GET: Teach
        public IEnumerable<Section> GetSections()
        {
            var sections = db.Sections.ToList();
            JsonConvert.SerializeObject(sections, Formatting.Indented);
            return sections;
        }
    }
}