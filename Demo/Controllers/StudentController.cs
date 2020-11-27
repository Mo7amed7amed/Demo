using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo.Models;

namespace Demo.Controllers
{
    public class StudentController : Controller
    {
        ITIModel db = new ITIModel();
        // GET: Student
        public ActionResult Index()
        {
            return View(db.Students.ToList());
            @ViewBag.title = "Student Create";
        }

        public ActionResult Create()
        {
            //List<Department> depts = db.Departments.ToList();
            ViewBag.DepartmentId = new SelectList(db.Departments.ToList(), "DeptId", "DeptName");
            @ViewBag.title = "Student Create";
            //ViewBag.dsl = deptsSl;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(std);
                db.SaveChanges();
             
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments.ToList(), "DeptId", "DeptName");
            return View(std);
            
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments.ToList(), "DeptId", "DeptName");
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "stdId,Name,Age,Email,PhoneNumber,DepartmentId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments.ToList(), "DeptId", "DeptName");
            return View(student);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CheckUserName(string UserName)
        {
            Student std = db.Students.FirstOrDefault(a => a.UserName == UserName);
            if (std == null)
                return Json(true, JsonRequestBehavior.AllowGet);
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}