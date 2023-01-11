using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project1.Models;
using ActionNameAttribute = Microsoft.AspNetCore.Mvc.ActionNameAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;

namespace Project1.Controllers
{
    [ApiController]
    public class AttController : System.Web.Http.ApiController
    {
        private IPT_ProjEntities db = new IPT_ProjEntities();

        // GET: Teach
        [HttpGet]
        //[Route("api/commands")]
        public IEnumerable<Attendance> GetAllAttendances()
        {
            var attendances = db.Attendances.ToList();
            JsonConvert.SerializeObject(attendances, Formatting.Indented);
            return attendances;
        }

        //System.Net.Http.HttpResponseMessage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public System.Net.Http.HttpResponseMessage Post([System.Web.Http.FromBody] Attendance[] attendance)
        {
            if (string.IsNullOrEmpty(attendance[0]?.Std_ID.ToString()))
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest);
                

            }

            db.Attendances.AddRange(attendance);

            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Created, attendance);
        }

        [HttpPut]
        public System.Net.Http.HttpResponseMessage Put(int id,[System.Web.Http.FromBody] Attendance attendance)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest);


            }

            attendance.Std_ID = id;
            db.Entry(attendance).State = EntityState.Modified;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, attendance);
        }

        [HttpDelete]
        public System.Net.Http.HttpResponseMessage Delete(int S_ID,int T_ID,int C_ID)
        {
            Attendance attendance = db.Attendances.Find(S_ID,T_ID,C_ID);
            db.Attendances.Remove(attendance);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, attendance);
        }
    }
}