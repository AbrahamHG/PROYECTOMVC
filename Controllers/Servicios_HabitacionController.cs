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
    public class Servicios_HabitacionController : Controller
    {
        private HotelEntities db = new HotelEntities();
        string titulos = "Correcto";


        // GET: Servicios_Habitacion
        public ActionResult Index()
        {
            var servicios_Habitacion = db.Servicios_Habitacion.Include(s => s.Empleados).Include(s => s.Habitaciones).Include(s => s.Servicios);
            return View(servicios_Habitacion.ToList());
        }

        // GET: Servicios_Habitacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios_Habitacion servicios_Habitacion = db.Servicios_Habitacion.Find(id);
            if (servicios_Habitacion == null)
            {
                return HttpNotFound();
            }
            return View(servicios_Habitacion);
        }

        // GET: Servicios_Habitacion/Create
        public ActionResult Create()
        {
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "ID_Empleado", "Nombre");
            ViewBag.Habitacion_ID = new SelectList(db.Habitaciones, "ID_Habitacion", "tipo");
            ViewBag.Servicio_ID = new SelectList(db.Servicios, "ID_Servicio", "Servicio");
            return View();
        }

        // POST: Servicios_Habitacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ServHab,Habitacion_ID,Servicio_ID,Empleado_ID,Fecha_Servicio")] Servicios_Habitacion servicios_Habitacion)
        {
            try
            {
                titulos = "Correcto";

                if (ModelState.IsValid)
                {
                    db.Servicios_Habitacion.Add(servicios_Habitacion);
                    db.SaveChanges();
                    SweetAlert(titulos, "Servicio Habitacion Agregado", NotificationType.success);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                SweetAlert("Opss..", $"Ha ocurrido un Error Verifique los Campos", NotificationType.error);
            }
            
           

            ViewBag.Empleado_ID = new SelectList(db.Empleados, "ID_Empleado", "Nombre", servicios_Habitacion.Empleado_ID);
            ViewBag.Habitacion_ID = new SelectList(db.Habitaciones, "ID_Habitacion", "tipo", servicios_Habitacion.Habitacion_ID);
            ViewBag.Servicio_ID = new SelectList(db.Servicios, "ID_Servicio", "Servicio", servicios_Habitacion.Servicio_ID);
            return View(servicios_Habitacion);
        }

        // GET: Servicios_Habitacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios_Habitacion servicios_Habitacion = db.Servicios_Habitacion.Find(id);
            if (servicios_Habitacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "ID_Empleado", "Nombre", servicios_Habitacion.Empleado_ID);
            ViewBag.Habitacion_ID = new SelectList(db.Habitaciones, "ID_Habitacion", "tipo", servicios_Habitacion.Habitacion_ID);
            ViewBag.Servicio_ID = new SelectList(db.Servicios, "ID_Servicio", "Servicio", servicios_Habitacion.Servicio_ID);
            return View(servicios_Habitacion);
        }

        // POST: Servicios_Habitacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ServHab,Habitacion_ID,Servicio_ID,Empleado_ID,Fecha_Servicio")] Servicios_Habitacion servicios_Habitacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicios_Habitacion).State = EntityState.Modified;
                db.SaveChanges();
                titulos = "Correcto";
                SweetAlert(titulos, "Servicio Habitacion Modificado", NotificationType.success);
                return RedirectToAction("Index");
            }
            ViewBag.Empleado_ID = new SelectList(db.Empleados, "ID_Empleado", "Nombre", servicios_Habitacion.Empleado_ID);
            ViewBag.Habitacion_ID = new SelectList(db.Habitaciones, "ID_Habitacion", "tipo", servicios_Habitacion.Habitacion_ID);
            ViewBag.Servicio_ID = new SelectList(db.Servicios, "ID_Servicio", "Servicio", servicios_Habitacion.Servicio_ID);
            return View(servicios_Habitacion);
        }

        // GET: Servicios_Habitacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicios_Habitacion servicios_Habitacion = db.Servicios_Habitacion.Find(id);
            if (servicios_Habitacion == null)
            {
                return HttpNotFound();
            }
            return View(servicios_Habitacion);
        }

        // POST: Servicios_Habitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicios_Habitacion servicios_Habitacion = db.Servicios_Habitacion.Find(id);
            db.Servicios_Habitacion.Remove(servicios_Habitacion);
            db.SaveChanges();
            titulos = "Correcto";
            SweetAlert(titulos, "Servicio Habitacion Eliminado", NotificationType.success);
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
