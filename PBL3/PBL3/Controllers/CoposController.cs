using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PBL3.Models;

namespace PBL3.Controllers
{
    public class CoposController : Controller
    {
        private PBL3Context db = new PBL3Context();

        // GET: Copos
        public ActionResult Index()
        {
            return View(db.Copoes.ToList());
        }

        // GET: Copos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copo copo = db.Copoes.Find(id);
            if (copo == null)
            {
                return HttpNotFound();
            }
            return View(copo);
        }

        // GET: Copos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Copos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CopoId,CopoMl")] Copo copo)
        {
            if (ModelState.IsValid)
            {
                db.Copoes.Add(copo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(copo);
        }

        // GET: Copos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copo copo = db.Copoes.Find(id);
            if (copo == null)
            {
                return HttpNotFound();
            }
            return View(copo);
        }

        // POST: Copos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CopoId,CopoMl")] Copo copo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(copo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(copo);
        }

        // GET: Copos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Copo copo = db.Copoes.Find(id);
            if (copo == null)
            {
                return HttpNotFound();
            }
            return View(copo);
        }

        // POST: Copos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Copo copo = db.Copoes.Find(id);
            db.Copoes.Remove(copo);
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
