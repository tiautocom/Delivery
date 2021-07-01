using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI.OBJETO.TRANSFERENCIA
{
    public class Producto
    {
        public int id { get; set; }
        public string codBarra { get; set; }
        public string  descricao { get; set; }
        public string unidade { get; set; }
        public string ingredientes { get; set; }
        public DateTime dtCadastro { get; set; }
        public string urlFoto { get; set; }

        public Departament  Departamento { get; set; }
        public Departamento_Produto Departamento_Produto { get; set; }
        public Produto_Observacao Produto_Observacao { get; set; }
    }
}
