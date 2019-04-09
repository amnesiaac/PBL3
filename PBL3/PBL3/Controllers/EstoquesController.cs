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
    public class EstoquesController : Controller
    {
        private PBL3Context db = new PBL3Context();

        // GET: Estoques
        public ActionResult Index()
        {
            var estoques = db.Estoques.Include(e => e.Copo);
            return View(estoques.ToList());
        }

        // GET: Estoques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = db.Estoques.Find(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            return View(estoque);
        }

        // GET: Estoques/Create
        public ActionResult Create()
        {
            ViewBag.CopoId = new SelectList(db.Copoes, "CopoId", "CopoMl");
            return View();
        }

        // POST: Estoques/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstoqueId,CopoId,QuaSacoCopos")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                db.Estoques.Add(estoque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CopoId = new SelectList(db.Copoes, "CopoId", "CopoMl", estoque.CopoId);
            return View(estoque);
        }

        // GET: Estoques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = db.Estoques.Find(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            ViewBag.CopoId = new SelectList(db.Copoes, "CopoId", "CopoMl", estoque.CopoId);
            return View(estoque);
        }

        // POST: Estoques/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstoqueId,CopoId,QuaSacoCopos")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estoque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CopoId = new SelectList(db.Copoes, "CopoId", "CopoMl", estoque.CopoId);
            return View(estoque);
        }

        // GET: Estoques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = db.Estoques.Find(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            return View(estoque);
        }

        // POST: Estoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estoque estoque = db.Estoques.Find(id);
            db.Estoques.Remove(estoque);
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
