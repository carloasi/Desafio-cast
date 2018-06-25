using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DesafioCast.Models;

namespace DesafioCast.Controllers
{
    public class adocaosController : Controller
    {
        private DbDesafioCastContext db = new DbDesafioCastContext();

        // GET: adocaos
        public ActionResult Index()
        {


            if (Session["usuario"] != null)
            {
                var adocaos = db.adocaos.Include(a => a.animal).Include(a => a.pessoa);
                return View(adocaos.ToList());
            }
            else
            {
                return RedirectToAction("Edit", "usuarios");
            }


            
        }

        // GET: adocaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adocao adocao = db.adocaos.Find(id);
            if (adocao == null)
            {
                return HttpNotFound();
            }
            return View(adocao);
        }

        // GET: adocaos/Create
        public ActionResult Create()
        {
            ViewBag.animalId = new SelectList(db.animals, "Id", "nome");
            ViewBag.pessoaId = new SelectList(db.pessoas, "id", "nome");
            return View();
        }

        // POST: adocaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataAdocao,pessoaId,animalId")] adocao adocao)
        {
            if (ModelState.IsValid)
            {
                db.adocaos.Add(adocao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.animalId = new SelectList(db.animals, "Id", "nome", adocao.animalId);
            ViewBag.pessoaId = new SelectList(db.pessoas, "id", "nome", adocao.pessoaId);
            return View(adocao);
        }

        // GET: adocaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adocao adocao = db.adocaos.Find(id);
            if (adocao == null)
            {
                return HttpNotFound();
            }
            ViewBag.animalId = new SelectList(db.animals, "Id", "nome", adocao.animalId);
            ViewBag.pessoaId = new SelectList(db.pessoas, "id", "nome", adocao.pessoaId);
            return View(adocao);
        }

        // POST: adocaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataAdocao,pessoaId,animalId")] adocao adocao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adocao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.animalId = new SelectList(db.animals, "Id", "nome", adocao.animalId);
            ViewBag.pessoaId = new SelectList(db.pessoas, "id", "nome", adocao.pessoaId);
            return View(adocao);
        }

        // GET: adocaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adocao adocao = db.adocaos.Find(id);
            if (adocao == null)
            {
                return HttpNotFound();
            }
            return View(adocao);
        }

        // POST: adocaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            adocao adocao = db.adocaos.Find(id);
            db.adocaos.Remove(adocao);
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
