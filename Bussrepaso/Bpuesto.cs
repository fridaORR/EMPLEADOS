using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;
using DDper;

namespace Bussrepaso
{
  public  class Bpuesto
    {

        Dpuesto data = new Dpuesto();
         public List<Epuesto> Obtener()
            {
                DataTable dt = data.Obtener();
                List<Epuesto> Lista = new List<Epuesto>();
                foreach (DataRow dr in dt.Rows)
                {
                   Epuesto per = new Epuesto ();


                    per.id = Convert.ToInt32(dr["id"]);
                    per.nombre = Convert.ToString(dr["nombre"]);
                 


                    Lista.Add(per);
                }
                return Lista;

            }

        public Epuesto ObtenerId(int id)
            {
                DataRow dr = data.ObtenerId(id);
            Epuesto per = new Epuesto();
                per.id = Convert.ToInt32(dr["id"]);
                per.nombre = Convert.ToString(dr["nombre"]);
             

                return per;
            }
            public void Agregar(Epuesto per)
            {
                int fa = data.Agregar(per.nombre );
                if (fa != 1)
                {
                    throw new ApplicationException($"Error  de aplicar{per.nombre}");
                }
            }

            public void Editar(Epuesto per)
            {
                int fa = data.Editar(per.nombre,per.id);
                if (fa != 1)

                {
                    throw new ApplicationException($"Error al editar a {per.nombre}");

                }
            }

            public void Eliminar(Epuesto per)
            {
                int fa = data.Eliminar(per.id);
                if (fa != 1)
                {
                    throw new ApplicationException($"Error al eliminar a {per.nombre}");

                }
            }
          

        }
    }

