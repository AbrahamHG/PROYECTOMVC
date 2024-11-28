using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PROYECTOMVC.Models;
using static PROYECTOMVC.Models.Enum;

namespace PROYECTOMVC.Controllers
{
    public class HabitacionesController : Controller
    {
        private HotelEntities db = new HotelEntities();
        string titulos = "";

        // GET: Habitaciones
        public ActionResult Index()
        {
            return View(db.Habitaciones.ToList());
        }

        // GET: Habitaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habitaciones habitaciones = db.Habitaciones.Find(id);
            if (habitaciones == null)
            {
                return HttpNotFound();
            }
            return View(habitaciones);
        }

        // GET: Habitaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Habitaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Habitacion,Numero_Habitacion,tipo,Precio,Estatus,Descripcion")] Habitaciones habitaciones)
        {
            try
            {
                titulos = "Correcto";

                if (ModelState.IsValid)
                {
                    db.Habitaciones.Add(habitaciones);
                    db.SaveChanges();
                    SweetAlert(titulos, "Habitacion Agregado", NotificationType.success);
                    return RedirectToAction("Index");
                }


            }
            catch (Exception)
            {

                SweetAlert("Opss..", $"Ha ocurrido un Error Verifique los Campos", NotificationType.error);
            }

            return View(habitaciones);
        }

        // GET: Habitaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habitaciones habitaciones = db.Habitaciones.Find(id);
            if (habitaciones == null)
            {
                return HttpNotFound();
            }
            return View(habitaciones);
        }

        // POST: Habitaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Habitacion,Numero_Habitacion,tipo,Precio,Estatus,Descripcion")] Habitaciones habitaciones)
        {
            if (ModelState.IsValid)
            {
                titulos = "Correcto";
                db.Entry(habitaciones).State = EntityState.Modified;
                db.SaveChanges();
                SweetAlert(titulos, "Habitacion Modificado", NotificationType.success);
                return RedirectToAction("Index");
            }
            return View(habitaciones);
        }

        // GET: Habitaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Habitaciones habitaciones = db.Habitaciones.Find(id);
            if (habitaciones == null)
            {
                return HttpNotFound();
            }
            return View(habitaciones);
        }

        // POST: Habitaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Habitaciones habitaciones = db.Habitaciones.Find(id);
            db.Habitaciones.Remove(habitaciones);
            db.SaveChanges();
            titulos = "Correcto";
            SweetAlert(titulos, "Habitacion Eliminado", NotificationType.success);
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

        #region Sweet Alert
        private void SweetAlert(string title, string msg, NotificationType type)
        {
            var script = "<script languaje='javascript'> " +
                                     "Swal.fire({" +
                                     "title: '" + title + "'," +
                                     "text: '" + msg + "'," +
                                     "icon: '" + type + "'" +
                                     "});" +
                                     "</script>";

            //TempData funciona como un viewBag, pasando información del controlador a cualquier parte de mi proyecto, siendo este más observable y con un tiempo de vida similar
            TempData["sweetalert"] = script;
        }


        #endregion
    }
}
