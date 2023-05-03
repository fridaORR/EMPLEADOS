using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public  class Eempleado
    {
         public int id { get; set; }

        public Epuesto puesto { get; set; }
        public Epersona persona { get; set; }
    }
}
