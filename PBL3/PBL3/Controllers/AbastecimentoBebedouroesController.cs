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
    public class AbastecimentoBebedouroesController : Controller
    {
        private PBL3Context db = new PBL3Context();

        // GET: AbastecimentoBebedouroes
        public ActionResult Index()
        {
            var abastecimentoBebedouroes = db.AbastecimentoBebedouroes.Include(a => a.Bebedouro).Include(a => a.Estoque);
            return View(abastecimentoBebedouroes.ToList());
        }

        // GET: AbastecimentoBebedouroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbastecimentoBebedouro abastecimentoBebedouro = db.AbastecimentoBebedouroes.Find(id);
            if (abastecimentoBebedouro == null)
            {
                return HttpNotFound();
            }
            return View(abastecimentoBebedouro);
        }

        // GET: AbastecimentoBebedouroes/Create
        public ActionResult Create()
        {
            ViewBag.BebedouroId = new SelectList(db.Bebedouroes.Where(b => b.TemSaco == false), "BebedouroId", "Localizacao");
            ViewBag.EstoqueId = new SelectList(db.Estoques.Where(c => c.QuaSacoCopos > 0), "EstoqueId", "EstoqueId");
            return View();
        }

        // POST: AbastecimentoBebedouroes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AbastecimentoBebedouroId,BebedouroId,EstoqueId")] AbastecimentoBebedouro abastecimentoBebedouro)
        {
            if (ModelState.IsValid)
            {
                Bebedouro bebedouro = db.Bebedouroes.Find(abastecimentoBebedouro.BebedouroId);
                abastecimentoBebedouro.Bebedouro = bebedouro;
                Estoque estoque = db.Estoques.Find(abastecimentoBebedouro.EstoqueId);
                abastecimentoBebedouro.Estoque = estoque;
                if (abastecimentoBebedouro.mudastatusBebedouro())
                {
                    db.AbastecimentoBebedouroes.Add(abastecimentoBebedouro);
                    db.SaveChanges();
                    bebedouro.TemSaco = true;
                    db.Entry(bebedouro).State = EntityState.Modified;
                    db.SaveChanges();
                }
                if (abastecimentoBebedouro.decrementaEstoque())
                {
                    db.AbastecimentoBebedouroes.Add(abastecimentoBebedouro);
                    db.SaveChanges();
                    estoque.QuaSacoCopos -= 1;
                    db.Entry(bebedouro).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            ViewBag.BebedouroId = new SelectList(db.Bebedouroes, "BebedouroId", "Localizacao", abastecimentoBebedouro.BebedouroId);
            ViewBag.EstoqueId = new SelectList(db.Estoques, "EstoqueId", "EstoqueId", abastecimentoBebedouro.EstoqueId);
            return View(abastecimentoBebedouro);
        }

        // GET: AbastecimentoBebedouroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbastecimentoBebedouro abastecimentoBebedouro = db.AbastecimentoBebedouroes.Find(id);
            if (abastecimentoBebedouro == null)
            {
                return HttpNotFound();
            }
            ViewBag.BebedouroId = new SelectList(db.Bebedouroes, "BebedouroId", "Localizacao", abastecimentoBebedouro.BebedouroId);
            ViewBag.EstoqueId = new SelectList(db.Estoques, "EstoqueId", "EstoqueId", abastecimentoBebedouro.EstoqueId);
            return View(abastecimentoBebedouro);
        }

        // POST: AbastecimentoBebedouroes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AbastecimentoBebedouroId,BebedouroId,EstoqueId")] AbastecimentoBebedouro abastecimentoBebedouro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abastecimentoBebedouro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BebedouroId = new SelectList(db.Bebedouroes, "BebedouroId", "Localizacao", abastecimentoBebedouro.BebedouroId);
            ViewBag.EstoqueId = new SelectList(db.Estoques, "EstoqueId", "EstoqueId", abastecimentoBebedouro.EstoqueId);
            return View(abastecimentoBebedouro);
        }

        // GET: AbastecimentoBebedouroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbastecimentoBebedouro abastecimentoBebedouro = db.AbastecimentoBebedouroes.Find(id);
            if (abastecimentoBebedouro == null)
            {
                return HttpNotFound();
            }
            return View(abastecimentoBebedouro);
        }

        // POST: AbastecimentoBebedouroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AbastecimentoBebedouro abastecimentoBebedouro = db.AbastecimentoBebedouroes.Find(id);
            db.AbastecimentoBebedouroes.Remove(abastecimentoBebedouro);
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
