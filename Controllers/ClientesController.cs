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
    public class ClientesController : Controller
    {
        private HotelEntities db = new HotelEntities();

        string titulos = "";
        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Cliente,Nombre,Apellido_Paterno,Apellido_Materno,Telefono,Email,Direccion")] Clientes clientes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    titulos = "Correcto";
                    db.Clientes.Add(clientes);
                    db.SaveChanges();
                    SweetAlert(titulos, "Cliente Agregado: " + clientes.Nombre + ' ' + clientes.Apellido_Paterno, NotificationType.success);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                SweetAlert("Opss..", $"Ha ocurrido un Error Verifique los Campos", NotificationType.error);
            }
           
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Cliente,Nombre,Apellido_Paterno,Apellido_Materno,Telefono,Email,Direccion")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                titulos = "Correcto";
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                SweetAlert(titulos, "Cliente Modificado", NotificationType.success);
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = db.Clientes.Find(id);
            db.Clientes.Remove(clientes);
            db.SaveChanges();
            titulos = "Correcto";
            SweetAlert(titulos, "Cliente Eliminado", NotificationType.success);
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
