using System;
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
    public class ContactTablesController : Controller
    {
        private SchoolMgtDbEntities db = new SchoolMgtDbEntities();

        // GET: ContactTables
        public ActionResult Index()
        {
            return View(db.ContactTables.ToList());
        }

        // GET: ContactTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactTable contactTable = db.ContactTables.Find(id);
            if (contactTable == null)
            {
                return HttpNotFound();
            }
            return View(contactTable);
        }

        // GET: ContactTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactTable contactTable = db.ContactTables.Find(id);
            if (contactTable == null)
            {
                return HttpNotFound();
            }
            return View(contactTable);
        }

        // POST: ContactTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactTable contactTable = db.ContactTables.Find(id);
            db.ContactTables.Remove(contactTable);
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
