using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using evidencia1.Models;
namespace evidencia1.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            using (var db = new inventario_2021Entities2())
            {
                return View(db.compra.ToList());
            }

        }

        public static string NombreUsuario(int idUsuario)
        {
            using (var db = new inventario_2021Entities2())
            {
                return db.usuario.Find(idUsuario).nombre;
            }
        }

        public static string NombreCliente(int idCliente)
        {
            using (var db = new inventario_2021Entities2())
            {
                return db.cliente.Find(idCliente).nombre;
            }
        }

        public ActionResult ListarUsuario()
        {
            using (var db = new inventario_2021Entities2())
            {
                return PartialView(db.usuario.ToList());
            }
        }

        public ActionResult ListarCliente()
        {
            using (var db = new inventario_2021Entities2())
            {
                return PartialView(db.cliente.ToList());
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(compra compra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario_2021Entities2())
                {
                    db.compra.Add(compra);
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
                return View(db.compra.Find(id));
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new inventario_2021Entities2())
            {
                compra compraEdit = db.compra.Where(a => a.id == id).FirstOrDefault();
                return View(compraEdit);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(compra compraEdit)
        {
            try
            {
                using (var db = new inventario_2021Entities2())
                {
                    var oldcompra = db.compra.Find(compraEdit.id);
                    oldcompra.id_usuario = compraEdit.id_usuario;
                    oldcompra.id_cliente = compraEdit.id_cliente;
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

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventario_2021Entities2())
                {
                    compra compra = db.compra.Find(id);
                    db.compra.Remove(compra);
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
        
    
