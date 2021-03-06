﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FerreteriaProMAX.Models;
using Microsoft.Ajax.Utilities;

namespace FerreteriaProMAX.Controllers
{
    public class USUARIO_LOGINController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();

        // GET: USUARIO_LOGIN
        public ActionResult Index()
        {
            var uSUARIO_LOGIN = db.USUARIO_LOGIN.Include(u => u.Persona);
            return View(uSUARIO_LOGIN.ToList());
        }

        // GET: USUARIO_LOGIN/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO_LOGIN uSUARIO_LOGIN = db.USUARIO_LOGIN.Find(id);
            if (uSUARIO_LOGIN == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO_LOGIN);
        }

        // GET: USUARIO_LOGIN/Create
        public ActionResult Create()
        {
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Cedula");
            return View();
        }

        // POST: USUARIO_LOGIN/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,Usuario,Contraseña,idPersona")] USUARIO_LOGIN uSUARIO_LOGIN)
        {
            if (ModelState.IsValid)
            {
                db.USUARIO_LOGIN.Add(uSUARIO_LOGIN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Cedula", uSUARIO_LOGIN.idPersona);
            return View(uSUARIO_LOGIN);
        }

        // GET: USUARIO_LOGIN/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO_LOGIN uSUARIO_LOGIN = db.USUARIO_LOGIN.Find(id);
            if (uSUARIO_LOGIN == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Cedula", uSUARIO_LOGIN.idPersona);
            return View(uSUARIO_LOGIN);
        }

        // POST: USUARIO_LOGIN/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,Usuario,Contraseña,idPersona")] USUARIO_LOGIN uSUARIO_LOGIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO_LOGIN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "Cedula", uSUARIO_LOGIN.idPersona);
            return View(uSUARIO_LOGIN);
        }

        // GET: USUARIO_LOGIN/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO_LOGIN uSUARIO_LOGIN = db.USUARIO_LOGIN.Find(id);
            if (uSUARIO_LOGIN == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO_LOGIN);
        }

        // POST: USUARIO_LOGIN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIO_LOGIN uSUARIO_LOGIN = db.USUARIO_LOGIN.Find(id);
            db.USUARIO_LOGIN.Remove(uSUARIO_LOGIN);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Session["id"] == null)
            {
                Session["id"] = "0";
                return View();
            }
            else if(!Session["id"].ToString().Equals("0"))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(String usuario, String contraseña)
        {
            if (usuario.IsNullOrWhiteSpace() | contraseña.IsNullOrWhiteSpace())
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataTable dt = new DataTable();
            SqlConnection PubsConn = new SqlConnection("Data Source=DESKTOP-48V98DF;integrated Security=sspi;initial catalog=FERRETERIADB;");
            SqlCommand testCMD = new SqlCommand("UserPassword", PubsConn);
            PubsConn.Open();
            testCMD.CommandType = CommandType.StoredProcedure;
            testCMD.Parameters.AddWithValue("@usuario", usuario);
            testCMD.Parameters.AddWithValue("@password", contraseña);
            USUARIO_LOGIN uSUARIO_LOGIN = db.USUARIO_LOGIN.Find(testCMD.ExecuteScalar());
            var result = false;
            if (uSUARIO_LOGIN == null)
            {
                PubsConn.Close();
                return HttpNotFound();
            }
            Session["id"] = uSUARIO_LOGIN.IdUsuario;
            result = true;
            switch (result)
            {
                case true:
                    PubsConn.Close();
                    return RedirectToAction("Index", "Home");
                case false:
                    PubsConn.Close();
                    return View("Login", "USUARIO_LOGIN");
                default:
                    PubsConn.Close();
                    return View();
            }



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
