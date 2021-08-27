using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI.ACESSO.DADOS;
using TI.OBJETO.TRANSFERENCIA;

namespace TI.TRGRA.NEGOCIOS
{
    public class UsuarioRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        public string Salvar(Usuario usuario)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@Nome", usuario.nome);
                conexaoSqlServer.AdicionarParametros("@Telefone", usuario.telefone);
                conexaoSqlServer.AdicionarParametros("@Senha", usuario.senha);
                conexaoSqlServer.AdicionarParametros("@IdTipoUsuario", 1);

                string ret = "";

                ret = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspUsuarioSalvar").ToString();

                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable Logar(string telEmail, string senha)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@LOGIN", telEmail);
                conexaoSqlServer.AdicionarParametros("@Senha", senha);

                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspUsuarioLogar");
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public DataTable ListarPrestador(string pesquisa, int tipo)
        //{
        //    try
        //    {
        //        conexaoSqlServer.LimparParametros();
        //        conexaoSqlServer.AdicionarParametros("@Nome", pesquisa);

        //        DataTable dadosTabela = new DataTable();

        //        if (tipo == 1)
        //        {
        //            dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspListarPrestadorNome");
        //        }
        //        else if (tipo == 2)
        //        {
        //            dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspListarPrestadorDocumento");
        //        }
        //        else if (tipo == 3)
        //        {
        //            dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspListarPrestadorPlaca");
        //        }
        //        else if (tipo == 4)
        //        {
        //            dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspListarPrestadorEmpresa");
        //        }
        //        else if (tipo == 5)
        //        {
        //            dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspListarPrestadorTelefone");
        //        }
        //        else
        //        {
        //            return null;
        //        }

        //        return dadosTabela;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public int SalvarPrestador(Prestador prestador)
        //{
        //    try
        //    {
        //        conexaoSqlServer.LimparParametros();
        //        conexaoSqlServer.AdicionarParametros("@Id", prestador.Id);
        //        conexaoSqlServer.AdicionarParametros("@Placa", prestador.Placa.Replace("_", ""));
        //        conexaoSqlServer.AdicionarParametros("@Tipo", prestador.Tipo);
        //        conexaoSqlServer.AdicionarParametros("@Nome", prestador.Nome);
        //        conexaoSqlServer.AdicionarParametros("@Empresa", prestador.Empresa);
        //        conexaoSqlServer.AdicionarParametros("@Data", DateTime.Now);
        //        conexaoSqlServer.AdicionarParametros("@Documento", prestador.Documento);
        //        conexaoSqlServer.AdicionarParametros("@Telefone", prestador.Telefone.Replace("_", "").Replace("(", "").Replace(")", "").Trim());
        //        conexaoSqlServer.AdicionarParametros("@Veiculo", prestador.Veiculo);
        //        conexaoSqlServer.AdicionarParametros("@Celular", prestador.Celular.Replace("_", "").Replace("(", "").Replace(")", "").Trim());

        //        int ret = 0;

        //        if (prestador.Id == 0)
        //        {
        //            ret = Convert.ToInt32(conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPrestadorSalvar").ToString());
        //        }
        //        else
        //        {
        //            ret = Convert.ToInt32(conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPrestadorAlterar").ToString());
        //        }

        //        return ret;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
