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
    public class ReaderController : Controller
    {
        private EntariaContext db = new EntariaContext();

        //
        // GET: /Reader/

        public ActionResult Index()
        {
            return View(db.Readers.ToList());
        }

        //
        // GET: /Reader/Details/5

        public ActionResult Details(int id = 0)
        {
            Reader reader = db.Readers.Find(id);
            if (reader == null)
            {
                return HttpNotFound();
            }
            return View(reader);
        }

        //
        // GET: /Reader/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Reader/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reader reader)
        {
            if (ModelState.IsValid)
            {
                db.Readers.Add(reader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reader);
        }

        //
        // GET: /Reader/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Reader reader = db.Readers.Find(id);
            if (reader == null)
            {
                return HttpNotFound();
            }
            return View(reader);
        }

        //
        // POST: /Reader/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reader reader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reader);
        }

        //
        // GET: /Reader/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Reader reader = db.Readers.Find(id);
            if (reader == null)
            {
                return HttpNotFound();
            }
            return View(reader);
        }

        //
        // POST: /Reader/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reader reader = db.Readers.Find(id);
            db.Readers.Remove(reader);
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