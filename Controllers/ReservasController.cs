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
    public class ReservasController : Controller
    {
        private HotelEntities db = new HotelEntities();
        string titulos = "";


        // GET: Reservas
        public ActionResult Index()
        {
            var reservas = db.Reservas.Include(r => r.Clientes).Include(r => r.Habitaciones);
            return View(reservas.ToList());
        }

        // GET: Reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = db.Reservas.Find(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            return View(reservas);
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "ID_Cliente", "Nombre");
            ViewBag.Habitacion_ID = new SelectList(db.Habitaciones, "ID_Habitacion", "tipo");
            return View();
        }

        // POST: Reservas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_reserva,Cliente_ID,Habitacion_ID,CheckIN,CheckOUT,Estatus")] Reservas reservas)
        {
            try
            {
                titulos = "Correcto";

                if (ModelState.IsValid)
                {
                    db.Reservas.Add(reservas);
                    db.SaveChanges();
                    SweetAlert(titulos, "Reserva Agregada Agregado", NotificationType.success);
                    return RedirectToAction("Index");
                }



            }
            catch (Exception)
            {

                SweetAlert("Opss..", $"Ha ocurrido un Error Verifique los Campos", NotificationType.error);
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "ID_Cliente", "Nombre", reservas.Cliente_ID);
            ViewBag.Habitacion_ID = new SelectList(db.Habitaciones, "ID_Habitacion", "tipo", reservas.Habitacion_ID);
            return View(reservas);
        }

        // GET: Reservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = db.Reservas.Find(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "ID_Cliente", "Nombre", reservas.Cliente_ID);
            ViewBag.Habitacion_ID = new SelectList(db.Habitaciones, "ID_Habitacion", "tipo", reservas.Habitacion_ID);
            return View(reservas);
        }

        // POST: Reservas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_reserva,Cliente_ID,Habitacion_ID,CheckIN,CheckOUT,Estatus")] Reservas reservas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservas).State = EntityState.Modified;
                db.SaveChanges();
                titulos = "Correcto";
                SweetAlert(titulos, "Reserva Modificado", NotificationType.success);
                titulos = "Correcto";

                return RedirectToAction("Index");
            }
            ViewBag.Cliente_ID = new SelectList(db.Clientes, "ID_Cliente", "Nombre", reservas.Cliente_ID);
            ViewBag.Habitacion_ID = new SelectList(db.Habitaciones, "ID_Habitacion", "tipo", reservas.Habitacion_ID);
            return View(reservas);
        }

        // GET: Reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = db.Reservas.Find(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            return View(reservas);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservas reservas = db.Reservas.Find(id);
            db.Reservas.Remove(reservas);
            db.SaveChanges();
            titulos = "Correcto";
            SweetAlert(titulos, "Reserva Eliminado", NotificationType.success);
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
