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
    public class animalsController : Controller
    {
        private DbDesafioCastContext db = new DbDesafioCastContext();

        // GET: animals
        public ActionResult Index()
        {


            if (Session["usuario"] != null)
            {
                var animals = db.animals.Include(a => a.raca);
                return View(animals.ToList());
            }
            else
            {
                return RedirectToAction("Edit", "usuarios");
            }

           
        }

        // GET: animals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            animal animal = db.animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: animals/Create
        public ActionResult Create()
        {
            ViewBag.racaId = new SelectList(db.racas, "id", "nomeraca");
            return View();
        }

        // POST: animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,idade,sexo,dataEntrada,racaId")] animal animal)
        {
            if (ModelState.IsValid)
            {
                db.animals.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.racaId = new SelectList(db.racas, "id", "nomeraca", animal.racaId);
            return View(animal);
        }

        // GET: animals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            animal animal = db.animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.racaId = new SelectList(db.racas, "id", "nomeraca", animal.racaId);
            return View(animal);
        }

        // POST: animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,idade,sexo,dataEntrada,racaId")] animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.racaId = new SelectList(db.racas, "id", "nomeraca", animal.racaId);
            return View(animal);
        }

        // GET: animals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            animal animal = db.animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            animal animal = db.animals.Find(id);
            db.animals.Remove(animal);
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
