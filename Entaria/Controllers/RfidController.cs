using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entaria.Models;

namespace Entaria.Controllers
{
    public class RfidController : Controller
    {
        private EntariaContext db = new EntariaContext();

        //
        // GET: /Rfid/

        public ActionResult Index()
        {
            return View(db.Rfids.ToList());
        }

        //
        // GET: /Rfid/Details/5

        public ActionResult Details(int id = 0)
        {
            Rfid rfid = db.Rfids.Find(id);
            if (rfid == null)
            {
                return HttpNotFound();
            }
            return View(rfid);
        }

        //
        // GET: /Rfid/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Rfid/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Rfid rfid)
        {
            if (ModelState.IsValid)
            {
                db.Rfids.Add(rfid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rfid);
        }

        //
        // GET: /Rfid/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Rfid rfid = db.Rfids.Find(id);
            if (rfid == null)
            {
                return HttpNotFound();
            }
            return View(rfid);
        }

        //
        // POST: /Rfid/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Rfid rfid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rfid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rfid);
        }

        //
        // GET: /Rfid/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Rfid rfid = db.Rfids.Find(id);
            if (rfid == null)
            {
                return HttpNotFound();
            }
            return View(rfid);
        }

        //
        // POST: /Rfid/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rfid rfid = db.Rfids.Find(id);
            db.Rfids.Remove(rfid);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}