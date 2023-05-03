using Bussrepaso;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repasonew.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        Bpersona obj = new Bpersona();
        public ActionResult Index()
        {

            try
            {
                List<Epersona> lista = obj.Obtener();

                return View(lista);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View(new List<Epersona>());
            }
        }
        public ActionResult AgregarGet()
        {

            return View();

        }
        public ActionResult AgregarPost(Epersona us)
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
                Epersona eb = obj.ObtenerId(id);
                return View(eb);

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");

            }
        }
        public ActionResult EditarPost(Epersona eb)
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
                Epersona eb = obj.ObtenerId(id);
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
