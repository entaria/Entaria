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
    public class ClientCardBalanceController : Controller
    {
        private EntariaContext db = new EntariaContext();

        //
        // GET: /ClientCardBalance/

        public ActionResult Index()
        {
            return View(db.ClientCardBalances.ToList());
        }

        //
        // GET: /ClientCardBalance/Details/5

        public ActionResult Details(int id = 0)
        {
            ClientCardBalance clientcardbalance = db.ClientCardBalances.Find(id);
            if (clientcardbalance == null)
            {
                return HttpNotFound();
            }
            return View(clientcardbalance);
        }

        //
        // GET: /ClientCardBalance/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ClientCardBalance/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCardBalance clientcardbalance)
        {
            if (ModelState.IsValid)
            {
                db.ClientCardBalances.Add(clientcardbalance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientcardbalance);
        }

        //
        // GET: /ClientCardBalance/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ClientCardBalance clientcardbalance = db.ClientCardBalances.Find(id);
            if (clientcardbalance == null)
            {
                return HttpNotFound();
            }
            return View(clientcardbalance);
        }

        //
        // POST: /ClientCardBalance/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientCardBalance clientcardbalance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientcardbalance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientcardbalance);
        }

        //
        // GET: /ClientCardBalance/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ClientCardBalance clientcardbalance = db.ClientCardBalances.Find(id);
            if (clientcardbalance == null)
            {
                return HttpNotFound();
            }
            return View(clientcardbalance);
        }

        //
        // POST: /ClientCardBalance/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientCardBalance clientcardbalance = db.ClientCardBalances.Find(id);
            db.ClientCardBalances.Remove(clientcardbalance);
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