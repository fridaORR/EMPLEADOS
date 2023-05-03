using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDper;
using Entity;

namespace Bussrepaso
{
    public class Bpersona
    {
        DDpersona data = new DDpersona();
    
        public List<Epersona> Obtener()
        {
            DataTable dt = data.Obtener();
            List<Epersona> Lista = new List<Epersona>();
            foreach (DataRow dr in dt.Rows)
            {
                Epersona  per = new Epersona();


                per.id = Convert.ToInt32(dr["id"]);
                per.nombre = Convert.ToString(dr["nombre"]);
                per.apellido = Convert.ToString(dr["apellido"]);
                per.fechaNacimiento = Convert.ToDateTime(dr["fechaNacimiento"]);


                Lista.Add(per);
            }
            return Lista;

        }

        public Epersona ObtenerId(int id)
        {
            DataRow dr = data.ObtenerId(id);
            Epersona per = new Epersona();
            per.id = Convert.ToInt32(dr["id"]);
            per.nombre = Convert.ToString(dr["nombre"]);
            per.apellido = Convert.ToString(dr["apellido"]);
            per.fechaNacimiento = Convert.ToDateTime(dr["fechaNacimiento"]);

            return per;
        }
        public void Agregar(Epersona per)
        {
            int fa = data.Agregar(per.nombre, per.apellido, per.fechaNacimiento);
            if (fa != 1)
            {
                throw new ApplicationException($"Error  de aplicar{per.nombre}");
            }
        }

        public void Editar(Epersona  per)
        {
            int fa = data.Editar(per.nombre, per.apellido, per.id, per.fechaNacimiento);
            if (fa != 1)

            {
                throw new ApplicationException($"Error al editar a {per.nombre}");

            }
        }

        public void Eliminar(Epersona per)
        {
            int fa = data.Eliminar(per.id);
            if (fa != 1)
            {
                throw new ApplicationException($"Error al eliminar a {per.nombre}");

            }
        }


    }
}
