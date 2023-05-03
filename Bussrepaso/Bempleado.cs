using DDper;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Bussrepaso
{
    public class Bempleado
    {
        Dempleados data = new Dempleados();


        public List<Eempleado> Obtener()
        {
            DataTable dt = data.Obtener();
            List<Eempleado> Lista = new List<Eempleado>();
            foreach (DataRow dr in dt.Rows)
            {
                Eempleado em = new Eempleado();
                Epersona per = new Epersona();
                Epuesto pu = new Epuesto();

                per.id = Convert.ToInt32(dr["idpersona"]);
                per.nombre = Convert.ToString(dr["nombre"]);
                per.apellido = Convert.ToString(dr["apellido"]);
                per.fechaNacimiento = Convert.ToDateTime(dr["fechaNacimiento"]);


                pu.id = Convert.ToInt32(dr["idpuesto"]);
                pu.nombre = Convert.ToString(dr["puesto"]);

                em.id = Convert.ToInt32(dr["id"]);
                em.persona = per;
                em.puesto = pu;

                Lista.Add(em);

            }
            return Lista;
        }

        public void Agregar (Eempleado m)
        {
            int fa = data.Agregar(m.puesto.id,m.persona.id);
            if (fa != 1)
            {
                throw new ApplicationException($"Error  de aplicar{m.puesto.id}");
            }
        }
    }
}