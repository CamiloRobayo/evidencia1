using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using evidencia1.Models;
namespace evidencia1.Controllers
{
    public class ProveedoresController : Controller
    {
        // GET: Proveedores
        public ActionResult Index()
        {
            using (var db = new inventario_2021Entities2())
            {
                return View(db.proveedor.ToList());
            }
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario_2021Entities2())
                {
                    db.proveedor.Add(proveedor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();


            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new inventario_2021Entities2())
            {
                var findprover = db.proveedor.Find(id);
                return View(findprover);
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventario_2021Entities2())
                {
                    var findprover = db.proveedor.Find(id);
                    db.proveedor.Remove(findprover);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario_2021Entities2())
                {
                    proveedor findprover = db.proveedor.Where(a => a.id == id).FirstOrDefault();
                    return View(findprover);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(proveedor editprover)
        {
            try
            {

                using (var db = new inventario_2021Entities2())
                {
                    proveedor prover = db.proveedor.Find(editprover.id);

                    prover.nombre = editprover.nombre;
                    prover.direccion = editprover.direccion;
                    prover.telefono = editprover.telefono;
                    prover.nombre_contacto = editprover.nombre_contacto;


                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }

        }
    
    }
}