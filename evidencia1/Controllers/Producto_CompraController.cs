using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using evidencia1.Models;
namespace evidencia1.Controllers
{
    public class Producto_CompraController : Controller
    {
        // GET: Producto_Compra
        public ActionResult Index()
        {
            using (var db = new inventario_2021Entities2())
            {
                return View(db.producto_compra.ToList());
            }

        }

        public static int TotalCompra (int idcompra)
        {
            using (var db = new inventario_2021Entities2())
            {
                return db.compra.Find(idcompra).total;
            }
        }

        public static string NombreProducto(int idproducto)
        {
            using (var db = new inventario_2021Entities2())
            {
                return db.producto.Find(idproducto).nombre;
            }
        }

        public ActionResult ListaCompra()
        {
            using (var db = new inventario_2021Entities2())
            {
                return PartialView(db.compra.ToList());
            }
        }

        public ActionResult ListarProducto()
        {
            using (var db = new inventario_2021Entities2())
            {
                return PartialView(db.producto.ToList());
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(producto_compra producto_Compra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario_2021Entities2())
                {
                    db.producto_compra.Add(producto_Compra);
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
                return View(db.producto_compra.Find(id));
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new inventario_2021Entities2())
            {
                producto_compra productocompraEdit = db.producto_compra.Where(a => a.id == id).FirstOrDefault();
                return View(productocompraEdit);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(producto_compra productocompraEdit)
        {
            try
            {
                using (var db = new inventario_2021Entities2())
                {
                    var oldproductocompra = db.producto_compra.Find(productocompraEdit.id);
                    oldproductocompra.id_compra = productocompraEdit.id_compra;
                    oldproductocompra.id_producto = productocompraEdit.id_producto;
                    oldproductocompra.cantidad = productocompraEdit.cantidad;
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
                    producto_compra producto_Compra = db.producto_compra.Find(id);
                    db.producto_compra.Remove(producto_Compra);
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