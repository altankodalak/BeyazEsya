using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeyazEsya.Models;
using BeyazEsya.Models.Context;

namespace BeyazEsya.Controllers
{
    public class KategorıController : Controller
    {
        private BeyazEsyaContext db = new BeyazEsyaContext();

        // GET: Kategorı
        public ActionResult Index()
        {
            return View(db.Kategoriler.ToList());
        }

        // GET: Kategorı/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorı kategorı = db.Kategoriler.Find(id);
            if (kategorı == null)
            {
                return HttpNotFound();
            }
            return View(kategorı);
        }

        // GET: Kategorı/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategorı/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KategorıAdi")] Kategorı kategorı)
        {
            if (ModelState.IsValid)
            {
                db.Kategoriler.Add(kategorı);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategorı);
        }

        // GET: Kategorı/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorı kategorı = db.Kategoriler.Find(id);
            if (kategorı == null)
            {
                return HttpNotFound();
            }
            return View(kategorı);
        }

        // POST: Kategorı/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KategorıAdi")] Kategorı kategorı)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategorı).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategorı);
        }

        // GET: Kategorı/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorı kategorı = db.Kategoriler.Find(id);
            if (kategorı == null)
            {
                return HttpNotFound();
            }
            return View(kategorı);
        }

        // POST: Kategorı/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategorı kategorı = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(kategorı);
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
