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
    public class LoyaltyCardHolderController : Controller
    { // well Done Adrian looks good
        private EntariaContext db = new EntariaContext();

        //
        // GET: /LoyaltyCardHolder/

        public ActionResult Index()
        {
            return View(db.LoyaltyCardHolders.ToList());
        }

        //
        // GET: /LoyaltyCardHolder/Details/5

        public ActionResult Details(int id = 0)
        {
            LoyaltyCardHolder loyaltycardholder = db.LoyaltyCardHolders.Find(id);
            if (loyaltycardholder == null)
            {
                return HttpNotFound();
            }
            return View(loyaltycardholder);
        }

        //
        // GET: /LoyaltyCardHolder/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LoyaltyCardHolder/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoyaltyCardHolder loyaltycardholder)
        {
            if (ModelState.IsValid)
            {
                db.LoyaltyCardHolders.Add(loyaltycardholder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loyaltycardholder);
        }

        //
        // GET: /LoyaltyCardHolder/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LoyaltyCardHolder loyaltycardholder = db.LoyaltyCardHolders.Find(id);
            if (loyaltycardholder == null)
            {
                return HttpNotFound();
            }
            return View(loyaltycardholder);
        }

        //
        // POST: /LoyaltyCardHolder/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LoyaltyCardHolder loyaltycardholder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loyaltycardholder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loyaltycardholder);
        }

        //
        // GET: /LoyaltyCardHolder/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LoyaltyCardHolder loyaltycardholder = db.LoyaltyCardHolders.Find(id);
            if (loyaltycardholder == null)
            {
                return HttpNotFound();
            }
            return View(loyaltycardholder);
        }

        //
        // POST: /LoyaltyCardHolder/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoyaltyCardHolder loyaltycardholder = db.LoyaltyCardHolders.Find(id);
            db.LoyaltyCardHolders.Remove(loyaltycardholder);
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