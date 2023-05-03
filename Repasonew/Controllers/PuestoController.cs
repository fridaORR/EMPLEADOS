using Bussrepaso;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repasonew.Controllers
{
    public class PuestoController : Controller
    {
        // GET: Puesto
        Bpuesto obj = new Bpuesto();
        public ActionResult Index()
        {

            try
            {
                List<Epuesto> lista = obj.Obtener();

                return View(lista);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View(new List<Epuesto>());
            }
        }
        public ActionResult AgregarGet()
        {

            return View();

        }
        public ActionResult AgregarPost(Epuesto us)
        {
            try
            {
                obj.Agregar(us);
                TempData["mensaje"] = $" {us.nombre}se agrego correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("AgregarGet");
            }


        }

        public ActionResult EditarGet(int id)
        {
            try
            {
                Epuesto eb = obj.ObtenerId(id);
                return View(eb);

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");

            }
        }
        public ActionResult EditarPost(Epuesto eb)
        {
            try
            {
                obj.Editar(eb);
                return RedirectToAction("Index");

            }
            catch (Exception ex)

            {
                TempData["error"] = ex.Message;
                return View("EditarGet", eb);

            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                Epuesto eb = obj.ObtenerId(id);
                obj.Eliminar(eb);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");

            }
        }
    }

}
