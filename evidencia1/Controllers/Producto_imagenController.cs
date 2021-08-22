using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using evidencia1.Models;
namespace evidencia1.Controllers
{
    public class Producto_imagenController : Controller
    {
        // GET: Producto_imagen
        public ActionResult Index()
        {
            using (var db = new inventario_2021Entities2())
            {
                return View(db.producto_imagen.ToList());
            }

        }

        public static string NombreProducto(int idproducto)
        {
            using (var db = new inventario_2021Entities2())
            {
                return db.producto.Find(idproducto).nombre;
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
        public ActionResult Create(producto_imagen producto_Imagen)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario_2021Entities2())
                {
                    db.producto_imagen.Add(producto_Imagen);
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
                return View(db.producto_imagen.Find(id));
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new inventario_2021Entities2())
            {
                producto_imagen productoimagenEdit = db.producto_imagen.Where(a => a.id == id).FirstOrDefault();
                return View(productoimagenEdit);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(producto_imagen productoimagenEdit)
        {
            try
            {
                using (var db = new inventario_2021Entities2())
                {
                    var oldproductoimagen = db.producto_imagen.Find(productoimagenEdit.id);
                    oldproductoimagen.imagen = productoimagenEdit.imagen;
                    oldproductoimagen.id_producto = productoimagenEdit.id_producto;
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
                    producto_imagen producto_imagen = db.producto_imagen.Find(id);
                    db.producto_imagen.Remove(producto_imagen);
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
        
    
