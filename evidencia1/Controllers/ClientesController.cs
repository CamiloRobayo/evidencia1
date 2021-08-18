using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using evidencia1.Models;
namespace evidencia1.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            using (var db = new inventario_2021Entities2())
            {
                return View(db.cliente.ToList());
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(cliente cliente)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario_2021Entities2())
                {
                    db.cliente.Add(cliente);
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
                var findente = db.cliente.Find(id);
                return View(findente);
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventario_2021Entities2())
                {
                    var findente = db.cliente.Find(id);
                    db.cliente.Remove(findente);
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
                    cliente findente = db.cliente.Where(a => a.id == id).FirstOrDefault();
                    return View(findente);
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
        public ActionResult Edit(cliente editente)
        {
            try
            {

                using (var db = new inventario_2021Entities2())
                {
                    cliente ente = db.cliente.Find(editente.id);

                    ente.nombre = editente.nombre;
                    ente.documento = editente.documento;
                    ente.email = editente.email;

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
        
    
