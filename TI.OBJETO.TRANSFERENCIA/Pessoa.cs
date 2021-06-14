using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI.OBJETO.TRANSFERENCIA
{
    public class Pessoa
    {
        public int Id { get; set; }
        public int idUsuarioCad { get; set; }
        public string NomeRazao { get; set; }
        public string Fantasia { get; set; }
        public string CpfCnpj { get; set; }
        public string RgIe { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Img_Logo { get; set; }
        public bool Ativo { get; set; }

        public PessoaEndereco Endereco { get; set; }
        public EmpresaPJ Empresa { get; set; }
    }
}
