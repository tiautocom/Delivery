using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI.OBJETO.TRANSFERENCIA
{
    public class Departament
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string urlFoto { get; set; }

        public Departament_Empresa Departament_Empresa { get; set; }

    }
}
