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
    public class SogutucusController : Controller
    {
        private BeyazEsyaContext db = new BeyazEsyaContext();

        // GET: Sogutucus
        public ActionResult Index()
        {
            var beyazEsyas = db.Sogutucu.Include(s => s.Kategorı);
            return View(beyazEsyas.ToList());
        }

        // GET: Sogutucus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sogutucu sogutucu = db.Sogutucu.Find(id);
            if (sogutucu == null)
            {
                return HttpNotFound();
            }
            return View(sogutucu);
        }

        // GET: Sogutucus/Create
        public ActionResult Create()
        {
            ViewBag.KategorıId = new SelectList(db.Kategoriler, "Id", "KategorıAdi");
            return View();
        }

        // POST: Sogutucus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Model,Renk,Boyutlar,KategorıId,SogutucuTıp,Hacım")] Sogutucu sogutucu)
        {
            if (ModelState.IsValid)
            {
                db.Sogutucu.Add(sogutucu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategorıId = new SelectList(db.Kategoriler, "Id", "KategorıAdi", sogutucu.KategorıId);
            return View(sogutucu);
        }

        // GET: Sogutucus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sogutucu sogutucu = db.Sogutucu.Find(id);
            if (sogutucu == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategorıId = new SelectList(db.Kategoriler, "Id", "KategorıAdi", sogutucu.KategorıId);
            return View(sogutucu);
        }

        // POST: Sogutucus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Model,Renk,Boyutlar,KategorıId,SogutucuTıp,Hacım")] Sogutucu sogutucu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sogutucu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategorıId = new SelectList(db.Kategoriler, "Id", "KategorıAdi", sogutucu.KategorıId);
            return View(sogutucu);
        }

        // GET: Sogutucus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sogutucu sogutucu = db.Sogutucu.Find(id);
            if (sogutucu == null)
            {
                return HttpNotFound();
            }
            return View(sogutucu);
        }

        // POST: Sogutucus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sogutucu sogutucu = db.Sogutucu.Find(id);
            db.Sogutucu.Remove(sogutucu);
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
