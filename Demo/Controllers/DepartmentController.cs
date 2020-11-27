using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo.Models;

namespace Demo.Controllers
{
    public class DepartmentController : Controller
    {
        private ITIModel db = new ITIModel();

        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "DeptId,DeptName,Capacity")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "DeptId,DeptName,Capacity")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailsAjax(int id)
        {
            Department model = db.Departments.FirstOrDefault(a => a.DeptId == id);
            return PartialView(model);
        }
        public ActionResult addcourse(int id)
        {
            List<Course> courses = db.Courses.ToList();

            return View(courses);
        }

        [HttpPost]
        public ActionResult addcourse(int id, int[] course)//modelbinder bind to array
        {
            Department dept = db.Departments.FirstOrDefault(a => a.DeptId == id);
            foreach (var item in course)
            {
                Course crs = db.Courses.FirstOrDefault(a => a.CrsId == item);
                //dept.Courses.FirstOrDefault(a => a.CrsId ==item)    if this return data this mean the crs in dept
                dept.Courses.Add(crs);
                db.SaveChanges();
            }
            /*foreach(KeyValuePair<string,string> item in course)
            {
                int x = int.Parse(item.Key);
                Course c = db.Courses.FirstOrDefault(a => a.CrsId == x);
                dept.Courses.Add(c);
                db.SaveChanges();
            }*/
            return RedirectToAction("index");
        }


    }
}
