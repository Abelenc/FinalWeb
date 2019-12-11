using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proyectofinalweb;

namespace proyectofinalweb.Controllers
{
    public class sociosController : Controller
    {
        private proyectofinalwebEntities db = new proyectofinalwebEntities();

        // GET: socios
        public ActionResult Index()
        {
            return View(db.socios.ToList());
        }

        // GET: socios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            socios socios = db.socios.Find(id);
            if (socios == null)
            {
                return HttpNotFound();
            }
            return View(socios);
        }

        // GET: socios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: socios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sociosId,nombre,apellido,cedula,Foto,direccion,telefono,sexo,edad,fecha_nacimiento,afiliados,membresia,lugar_trabajo,direccion_oficina,tel_oficina,Estado_miembresia,fecha_ingreso,fecha_salida")] socios socios)
        {
            if (ModelState.IsValid)
            {
                db.socios.Add(socios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socios);
        }

        // GET: socios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            socios socios = db.socios.Find(id);
            if (socios == null)
            {
                return HttpNotFound();
            }
            return View(socios);
        }

        // POST: socios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sociosId,nombre,apellido,cedula,Foto,direccion,telefono,sexo,edad,fecha_nacimiento,afiliados,membresia,lugar_trabajo,direccion_oficina,tel_oficina,Estado_miembresia,fecha_ingreso,fecha_salida")] socios socios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socios);
        }

        // GET: socios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            socios socios = db.socios.Find(id);
            if (socios == null)
            {
                return HttpNotFound();
            }
            return View(socios);
        }

        // POST: socios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            socios socios = db.socios.Find(id);
            db.socios.Remove(socios);
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
