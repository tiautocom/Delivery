using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI.OBJETO.TRANSFERENCIA
{
    public class EmpresaPJ
    {
        public int Id { get; set; }
        public string IM { get; set; }
        public string HoraAbertura { get; set; }
        public string HoraFechamento { get; set; }
        public string Img_Logo { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public int idPessoa { get; set; }
        public int idUsuarioCad { get; set; }
        public int idSetor { get; set; }

    }
}
