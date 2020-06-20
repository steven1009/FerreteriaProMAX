using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FerreteriaProMAX.Models;

namespace FerreteriaProMAX.Controllers
{
    public class DetalleProvProdsController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();

        // GET: DetalleProvProds
        public ActionResult Index()
        {
            var detalleProvProd = db.DetalleProvProd.Include(d => d.proveedores);
            return View(detalleProvProd.ToList());
        }

        // GET: DetalleProvProds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProvProd detalleProvProd = db.DetalleProvProd.Find(id);
            if (detalleProvProd == null)
            {
                return HttpNotFound();
            }
            return View(detalleProvProd);
        }

        // GET: DetalleProvProds/Create
        public ActionResult Create()
        {
            ViewBag.IdProveedores = new SelectList(db.proveedores, "IdProveedores", "Nombre");
            return View();
        }

        // POST: DetalleProvProds/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDetalleProvProd,Fecha,IdProveedores")] DetalleProvProd detalleProvProd)
        {
            if (ModelState.IsValid)
            {
                db.DetalleProvProd.Add(detalleProvProd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProveedores = new SelectList(db.proveedores, "IdProveedores", "Nombre", detalleProvProd.IdProveedores);
            return View(detalleProvProd);
        }

        // GET: DetalleProvProds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProvProd detalleProvProd = db.DetalleProvProd.Find(id);
            if (detalleProvProd == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProveedores = new SelectList(db.proveedores, "IdProveedores", "Nombre", detalleProvProd.IdProveedores);
            return View(detalleProvProd);
        }

        // POST: DetalleProvProds/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetalleProvProd,Fecha,IdProveedores")] DetalleProvProd detalleProvProd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleProvProd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProveedores = new SelectList(db.proveedores, "IdProveedores", "Nombre", detalleProvProd.IdProveedores);
            return View(detalleProvProd);
        }

        // GET: DetalleProvProds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProvProd detalleProvProd = db.DetalleProvProd.Find(id);
            if (detalleProvProd == null)
            {
                return HttpNotFound();
            }
            return View(detalleProvProd);
        }

        // POST: DetalleProvProds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleProvProd detalleProvProd = db.DetalleProvProd.Find(id);
            db.DetalleProvProd.Remove(detalleProvProd);
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
