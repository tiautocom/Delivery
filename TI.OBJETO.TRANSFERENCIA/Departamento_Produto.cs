using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI.OBJETO.TRANSFERENCIA
{
    public class Departamento_Produto
    {
        public int id { get; set; }
        public int idProrduto { get; set; }
        public int idDepartamento { get; set; }
        public int idEmpresa { get; set; }
        public decimal preco { get; set; }
        public decimal custo { get; set; }
        public decimal estoque { get; set; }
        public string granel { get; set; }
        public bool ativo { get; set; }

        public Producto Produto { get; set; }
        public Departament Departamento { get; set; }
        public EmpresaPJ Empresa { get; set; }
    }
}
