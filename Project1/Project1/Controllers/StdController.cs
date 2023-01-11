using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project1.Models;

namespace Project1.Controllers
{
    [ApiController]
    public class StdController : System.Web.Http.ApiController
    {
        private IPT_ProjEntities db = new IPT_ProjEntities();

        // GET: Teach
        [DisableCors]
        public System.Net.Http.HttpResponseMessage GetAllStudents()
        {
            var students = db.Students.ToList();
            JsonConvert.SerializeObject(students, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK, students);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }

        public IEnumerable<Student> GetStudents(int section,int department)
        {
            var students = db.Students.SqlQuery("select * from [IPT_Proj].[dbo].[students] where sec_id = @sec_id and dept_id=@dept_id",new System.Data.SqlClient.SqlParameter("@sec_id",section), new System.Data.SqlClient.SqlParameter("@dept_id", department)).ToList();
            JsonConvert.SerializeObject(students, Formatting.Indented);
            return students;
        }


    }
}