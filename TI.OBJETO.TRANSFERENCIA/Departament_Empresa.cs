using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI.OBJETO.TRANSFERENCIA
{
    public class Departament_Empresa
    {
        public int id { get; set; }
        public int idEmpresa { get; set; }
        public int idDepartamento { get; set; }
        public string URL_Foto { get; set; }

        public Departament Departament { get; set; }
        public EmpresaPJ Empresa { get; set; }
    }
}
