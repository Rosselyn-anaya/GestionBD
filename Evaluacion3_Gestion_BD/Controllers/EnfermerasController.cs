using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Evaluacion3_Gestion_BD.Models;

namespace Evaluacion3_Gestion_BD.Controllers
{
    public class EnfermerasController : Controller
    {
        private consultorioEntities db = new consultorioEntities();

        // GET: Enfermeras
        public ActionResult Index()
        {
            var enfermera = db.Enfermera.Include(e => e.Medico);
            return View(enfermera.ToList());
        }

        // GET: Enfermeras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enfermera enfermera = db.Enfermera.Find(id);
            if (enfermera == null)
            {
                return HttpNotFound();
            }
            return View(enfermera);
        }

        // GET: Enfermeras/Create
        public ActionResult Create()
        {
            ViewBag.id_medico = new SelectList(db.Medico, "id_medico", "Nombre");
            return View();
        }

        // POST: Enfermeras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_enfermera,Nombre,Apellido,Edad,Area,id_medico")] Enfermera enfermera)
        {
            if (ModelState.IsValid)
            {
                db.Enfermera.Add(enfermera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_medico = new SelectList(db.Medico, "id_medico", "Nombre", enfermera.id_medico);
            return View(enfermera);
        }

        // GET: Enfermeras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enfermera enfermera = db.Enfermera.Find(id);
            if (enfermera == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_medico = new SelectList(db.Medico, "id_medico", "Nombre", enfermera.id_medico);
            return View(enfermera);
        }

        // POST: Enfermeras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_enfermera,Nombre,Apellido,Edad,Area,id_medico")] Enfermera enfermera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enfermera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_medico = new SelectList(db.Medico, "id_medico", "Nombre", enfermera.id_medico);
            return View(enfermera);
        }

        // GET: Enfermeras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enfermera enfermera = db.Enfermera.Find(id);
            if (enfermera == null)
            {
                return HttpNotFound();
            }
            return View(enfermera);
        }

        // POST: Enfermeras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enfermera enfermera = db.Enfermera.Find(id);
            db.Enfermera.Remove(enfermera);
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
