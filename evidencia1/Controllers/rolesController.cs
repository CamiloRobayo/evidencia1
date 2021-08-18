using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using evidencia1.Models;

namespace evidencia1.Controllers
{
    public class rolesController : Controller
    {
        // GET: roles
        public ActionResult Index()
        {
            using (var bd = new inventario_2021Entities2())
            {
                return View(bd.roles.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(roles roles)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var bd = new inventario_2021Entities2())
                {
                    bd.roles.Add(roles);
                    bd.SaveChanges();
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
            using (var bd = new inventario_2021Entities2())
            {
                var findrol = bd.roles.Find(id);
                return View(findrol);
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                using (var bd = new inventario_2021Entities2())
                {
                    var findrol = bd.roles.Find(id);
                    bd.roles.Remove(findrol);
                    bd.SaveChanges();
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
                using (var bd = new inventario_2021Entities2())
                {
                    roles findrol = bd.roles.Where(a => a.id == id).FirstOrDefault();
                    return View(findrol);
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
        public ActionResult Edit(roles editroles)
        {
            try
            {

                using (var bd = new inventario_2021Entities2())
                {
                    roles roll = bd.roles.Find(editroles.id);

                    roll.descripcion = editroles.descripcion;

                    bd.SaveChanges();
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
        
    
