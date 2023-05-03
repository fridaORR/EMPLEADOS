using Bussrepaso;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repasonew.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        Bempleado obj = new Bempleado();
        Bpuesto objpu = new Bpuesto();
        Bpersona obp = new Bpersona();

        public ActionResult Index()
        {

            try
            {
                List<Eempleado> lista = obj.Obtener();

                return View(lista);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View(new List<Eempleado>());
            }
        }

        public ActionResult AgregarGet()
        {
            List<Epuesto> elp = objpu.Obtener();
            List<Epersona> elper = obp.Obtener();
            ViewBag.puesto = new SelectList(elp, "id", "nombre");
            ViewBag.persona = new SelectList(elper, "id", "nombre");
            return View();

        }
        public ActionResult AgregarPost(Eempleado us)
        {
            try
            {
               
                obj.Agregar(us);
                TempData["mensaje"] = $" {us.puesto}se agrego correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("AgregarGet");
            }


        }
    }
}
