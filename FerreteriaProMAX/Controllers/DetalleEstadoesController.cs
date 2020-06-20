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
    public class DetalleEstadoesController : Controller
    {
        private FerreteriaDBEntities db = new FerreteriaDBEntities();

        // GET: DetalleEstadoes
        public ActionResult Index()
        {
            var detalleEstado = db.DetalleEstado.Include(d => d.Estado).Include(d => d.Empleado);
            return View(detalleEstado.ToList());
        }

        // GET: DetalleEstadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleEstado detalleEstado = db.DetalleEstado.Find(id);
            if (detalleEstado == null)
            {
                return HttpNotFound();
            }
            return View(detalleEstado);
        }

        // GET: DetalleEstadoes/Create
        public ActionResult Create()
        {
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "Estado1");
            ViewBag.idEmpleado = new SelectList(db.Empleado, "IdEmpleado", "IdEmpleado");
            return View();
        }

        // POST: DetalleEstadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDetalleEstado,IdEstado,FechaInicio,FechaFIN,idEmpleado")] DetalleEstado detalleEstado)
        {
            if (ModelState.IsValid)
            {
                db.DetalleEstado.Add(detalleEstado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "Estado1", detalleEstado.IdEstado);
            ViewBag.idEmpleado = new SelectList(db.Empleado, "IdEmpleado", "IdEmpleado", detalleEstado.idEmpleado);
            return View(detalleEstado);
        }

        // GET: DetalleEstadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleEstado detalleEstado = db.DetalleEstado.Find(id);
            if (detalleEstado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "Estado1", detalleEstado.IdEstado);
            ViewBag.idEmpleado = new SelectList(db.Empleado, "IdEmpleado", "IdEmpleado", detalleEstado.idEmpleado);
            return View(detalleEstado);
        }

        // POST: DetalleEstadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDetalleEstado,IdEstado,FechaInicio,FechaFIN,idEmpleado")] DetalleEstado detalleEstado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleEstado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "Estado1", detalleEstado.IdEstado);
            ViewBag.idEmpleado = new SelectList(db.Empleado, "IdEmpleado", "IdEmpleado", detalleEstado.idEmpleado);
            return View(detalleEstado);
        }

        // GET: DetalleEstadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleEstado detalleEstado = db.DetalleEstado.Find(id);
            if (detalleEstado == null)
            {
                return HttpNotFound();
            }
            return View(detalleEstado);
        }

        // POST: DetalleEstadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleEstado detalleEstado = db.DetalleEstado.Find(id);
            db.DetalleEstado.Remove(detalleEstado);
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
