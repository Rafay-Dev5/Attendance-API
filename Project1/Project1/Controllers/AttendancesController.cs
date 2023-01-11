using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project1.Models;

namespace Project1.Controllers
{
    public class AttendancesController : Controller
    {
        private IPT_ProjEntities db = new IPT_ProjEntities();

        // GET: Attendances
        public ActionResult Index()
        {
            var attendances = db.Attendances.Include(a => a.Cours).Include(a => a.Student).Include(a => a.Teacher);
            return View(attendances.ToList());
        }

        // GET: Attendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: Attendances/Create
        public ActionResult Create()
        {
            ViewBag.Course_ID = new SelectList(db.Courses, "Course_ID", "Course_name");
            ViewBag.Std_ID = new SelectList(db.Students, "Std_ID", "Std_name");
            ViewBag.Teach_ID = new SelectList(db.Teachers, "Teach_ID", "Teach_name");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Std_ID,Teach_ID,Course_ID,Attendance1,Date")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Attendances.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_ID = new SelectList(db.Courses, "Course_ID", "Course_name", attendance.Course_ID);
            ViewBag.Std_ID = new SelectList(db.Students, "Std_ID", "Std_name", attendance.Std_ID);
            ViewBag.Teach_ID = new SelectList(db.Teachers, "Teach_ID", "Teach_name", attendance.Teach_ID);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_ID = new SelectList(db.Courses, "Course_ID", "Course_name", attendance.Course_ID);
            ViewBag.Std_ID = new SelectList(db.Students, "Std_ID", "Std_name", attendance.Std_ID);
            ViewBag.Teach_ID = new SelectList(db.Teachers, "Teach_ID", "Teach_name", attendance.Teach_ID);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Std_ID,Teach_ID,Course_ID,Attendance1,Date")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_ID = new SelectList(db.Courses, "Course_ID", "Course_name", attendance.Course_ID);
            ViewBag.Std_ID = new SelectList(db.Students, "Std_ID", "Std_name", attendance.Std_ID);
            ViewBag.Teach_ID = new SelectList(db.Teachers, "Teach_ID", "Teach_name", attendance.Teach_ID);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendance attendance = db.Attendances.Find(id);
            db.Attendances.Remove(attendance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
