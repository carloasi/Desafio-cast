﻿using System;
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
    public class usuariosController : Controller
    {
        private DbDesafioCastContext db = new DbDesafioCastContext();

        // GET: usuarios
        public ActionResult Index()
        {


            if (Session["usuario"] != null)
            {
                return View(db.usuarios.ToList());
            }
            else
            {
                return RedirectToAction("Edit", "usuarios");
            }

            
        }

        public  ActionResult login(usuario u)
        {
          
            return View(u);
        }

        // GET: usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nomeusuario,senha")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Edit");
            }

            return View(usuario);
        }

        // GET: usuarios/Edit/5
        public ActionResult Edit(usuario u)
        {

            if (u.nomeusuario != null)
            {

                //Instancia classe de acesso a dados.
                DbDesafioCastContext obj = new DbDesafioCastContext();

                List<usuario> list = obj.usuarios.ToList();

                for (int i = 0; i < list.Count(); i++)
                {
                    if (list[i].nomeusuario == u.nomeusuario)
                    {
                        if (list[i].senha == u.senha)
                        {
                            Session["usuario"] = u.nomeusuario;

                            @ViewBag.usario = u.nomeusuario;

                            return RedirectToAction("Index", "Home", "home");
                        }
                    }

                }


            }
            else
            {
                u.nomeusuario = "";
                u.senha = "";
            }

            @ViewBag.usario = u.senha;

            return View(u);
        }

   

        // GET: usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuario usuario = db.usuarios.Find(id);
            db.usuarios.Remove(usuario);
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
