using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI.ACESSO.DADOS;

namespace TI.TRGRA.NEGOCIOS
{
    public class EmpresaRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        public DataTable ListarAll()
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspListarEmpresa");
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarTipoAdministradoraId(int idAdm)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@IdAdministradora", idAdm);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspTipoAdministradoraId");
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarAdminitracaoId(int idAdm)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@IdAdministradora", idAdm);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspAdministradoraPesquisarIdId");
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
