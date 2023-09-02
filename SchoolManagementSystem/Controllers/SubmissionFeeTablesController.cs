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
    public class SubmissionFeeTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: SubmissionFeeTables
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var submissionFeeTables = db.SubmissionFeeTables.Include(s => s.ClassTable).Include(s => s.ProgrameTable).Include(s => s.StudentTable).Include(s => s.UserTable);
            return View(submissionFeeTables.ToList());
        }

        // GET: SubmissionFeeTables/Details/5
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
            SubmissionFeeTable submissionFeeTable = db.SubmissionFeeTables.Find(id);
            if (submissionFeeTable == null)
            {
                return HttpNotFound();
            }
            return View(submissionFeeTable);
        }

        // GET: SubmissionFeeTables/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name");
            ViewBag.ProgrameID = new SelectList(db.ProgrameTables, "ProgrameID", "Name");
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: SubmissionFeeTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubmissionFeeID,UserID,ClassID,StudentID,Amount,ProgrameID,SubmissionDate,FeesMonth,Description")] SubmissionFeeTable submissionFeeTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            submissionFeeTable.UserID = userid;
            if (ModelState.IsValid)
            {
                db.SubmissionFeeTables.Add(submissionFeeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", submissionFeeTable.ClassID);
            ViewBag.ProgrameID = new SelectList(db.ProgrameTables, "ProgrameID", "Name", submissionFeeTable.ProgrameID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", submissionFeeTable.StudentID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", submissionFeeTable.UserID);
            return View(submissionFeeTable);
        }

        // GET: SubmissionFeeTables/Edit/5
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
            SubmissionFeeTable submissionFeeTable = db.SubmissionFeeTables.Find(id);
            if (submissionFeeTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", submissionFeeTable.ClassID);
            ViewBag.ProgrameID = new SelectList(db.ProgrameTables, "ProgrameID", "Name", submissionFeeTable.ProgrameID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", submissionFeeTable.StudentID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", submissionFeeTable.UserID);
            return View(submissionFeeTable);
        }

        // POST: SubmissionFeeTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubmissionFeeID,UserID,ClassID,StudentID,Amount,ProgrameID,SubmissionDate,FeesMonth,Description")] SubmissionFeeTable submissionFeeTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            submissionFeeTable.UserID = userid;
            if (ModelState.IsValid)
            {
                db.Entry(submissionFeeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.ClassTables, "ClassID", "Name", submissionFeeTable.ClassID);
            ViewBag.ProgrameID = new SelectList(db.ProgrameTables, "ProgrameID", "Name", submissionFeeTable.ProgrameID);
            ViewBag.StudentID = new SelectList(db.StudentTables, "StudentID", "Name", submissionFeeTable.StudentID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", submissionFeeTable.UserID);
            return View(submissionFeeTable);
        }

        // GET: SubmissionFeeTables/Delete/5
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
            SubmissionFeeTable submissionFeeTable = db.SubmissionFeeTables.Find(id);
            if (submissionFeeTable == null)
            {
                return HttpNotFound();
            }
            return View(submissionFeeTable);
        }

        // POST: SubmissionFeeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            SubmissionFeeTable submissionFeeTable = db.SubmissionFeeTables.Find(id);
            db.SubmissionFeeTables.Remove(submissionFeeTable);
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
