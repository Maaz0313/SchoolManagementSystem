﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseAccess;

namespace SchoolManagementSystem.Controllers
{
    public class StudentTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: StudentTables
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var studentTables = db.StudentTables.Include(s => s.ProgrameTable).Include(s => s.SessionTable).Include(s => s.UserTable);
            return View(studentTables.ToList());
        }

        // GET: StudentTables/Details/5
        public ActionResult Details(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTable studentTable = db.StudentTables.Find(id);
            if (studentTable == null)
            {
                return HttpNotFound();
            }
            return View(studentTable);
        }

        // GET: StudentTables/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.ProgrameID = new SelectList(db.ProgrameTables, "ProgrameID", "Name");
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: StudentTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,SessionID,ProgrameID,UserID,Name,FatherName,DateofBirth,Gender,ContactNo,CNIC,FNIC,Photo,IsEnrolled,ApplyDate,IsShortList,IsApply,PreviousSchool,PreviousPercentage,EmailAddress,Address")] StudentTable studentTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            studentTable.UserID = userid;
            if (ModelState.IsValid)
            {
                db.StudentTables.Add(studentTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgrameID = new SelectList(db.ProgrameTables, "ProgrameID", "Name", studentTable.ProgrameID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", studentTable.SessionID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", studentTable.UserID);
            return View(studentTable);
        }

        // GET: StudentTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTable studentTable = db.StudentTables.Find(id);
            if (studentTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgrameID = new SelectList(db.ProgrameTables, "ProgrameID", "Name", studentTable.ProgrameID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", studentTable.SessionID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", studentTable.UserID);
            return View(studentTable);
        }

        // POST: StudentTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,SessionID,ProgrameID,UserID,Name,FatherName,DateofBirth,Gender,ContactNo,CNIC,FNIC,Photo,IsEnrolled,ApplyDate,IsShortList,IsApply,PreviousSchool,PreviousPercentage,EmailAddress,Address")] StudentTable studentTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            studentTable.UserID = userid;
            if (ModelState.IsValid)
            {
                db.Entry(studentTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgrameID = new SelectList(db.ProgrameTables, "ProgrameID", "Name", studentTable.ProgrameID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", studentTable.SessionID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", studentTable.UserID);
            return View(studentTable);
        }

        // GET: StudentTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTable studentTable = db.StudentTables.Find(id);
            if (studentTable == null)
            {
                return HttpNotFound();
            }
            return View(studentTable);
        }

        // POST: StudentTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            StudentTable studentTable = db.StudentTables.Find(id);
            db.StudentTables.Remove(studentTable);
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
