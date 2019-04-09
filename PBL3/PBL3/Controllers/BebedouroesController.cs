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
    public class BebedouroesController : Controller
    {
        private PBL3Context db = new PBL3Context();

        // GET: Bebedouroes
        public ActionResult Index()
        {
            return View(db.Bebedouroes.ToList());
        }

        // GET: Bebedouroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bebedouro bebedouro = db.Bebedouroes.Find(id);
            if (bebedouro == null)
            {
                return HttpNotFound();
            }
            return View(bebedouro);
        }

        // GET: Bebedouroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bebedouroes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BebedouroId,Localizacao,TemSaco")] Bebedouro bebedouro)
        {
            if (ModelState.IsValid)
            {
                db.Bebedouroes.Add(bebedouro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bebedouro);
        }

        // GET: Bebedouroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bebedouro bebedouro = db.Bebedouroes.Find(id);
            if (bebedouro == null)
            {
                return HttpNotFound();
            }
            return View(bebedouro);
        }

        // POST: Bebedouroes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BebedouroId,Localizacao,TemSaco")] Bebedouro bebedouro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bebedouro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bebedouro);
        }

        // GET: Bebedouroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bebedouro bebedouro = db.Bebedouroes.Find(id);
            if (bebedouro == null)
            {
                return HttpNotFound();
            }
            return View(bebedouro);
        }

        // POST: Bebedouroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bebedouro bebedouro = db.Bebedouroes.Find(id);
            db.Bebedouroes.Remove(bebedouro);
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
