using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI.ACESSO.DADOS;
using TI.OBJETO.TRANSFERENCIA;

namespace TI.TRGRA.NEGOCIOS
{
    public class PessoaRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        #region VariaveisConstrutores

        string idRetorno;

        SqlCommand comandSql = new SqlCommand();
        StringBuilder sql = new StringBuilder();
        DataTable dadosTabela = new DataTable();
        #endregion

        public DataTable Login()
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspLogin");
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable Pesquisar()
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspListarEmpresas");
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable Pesquisar(int nomeEmpresa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_EMPRESA", nomeEmpresa);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspListarDepartamentoIdEmpresa");
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarNome(string nomeEmpresa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                //conexaoSqlServer.AdicionarParametros("@NOME_EMPRESA", nomeEmpresa);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspListarEmpresas");
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisarId(int idEmpresa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                //conexaoSqlServer.AdicionarParametros("@ID_EMPRESA", idEmpresa);
                conexaoSqlServer.AdicionarParametros("@ID", idEmpresa);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspListarEmpresaId");
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region Add_Update
        public string AddEmpresa(Pessoa pessoa,  int opcao)
        {
            try
            {
                //0PCAO 1=CADASTRAR - 2=ALTERAR
                conexaoSqlServer.LimparParametros();

                // conexaoSqlServer.AdicionarParametros("@Tipo", opcao);
                conexaoSqlServer.AdicionarParametros("@NOME_RAZAO", pessoa.Fantasia);
                conexaoSqlServer.AdicionarParametros("@FANTASIA", pessoa.Fantasia);
                conexaoSqlServer.AdicionarParametros("@CPF_CNPJ", pessoa.CpfCnpj);
                conexaoSqlServer.AdicionarParametros("@RG_IE", pessoa.RgIe);
                conexaoSqlServer.AdicionarParametros("@EMAIL", pessoa.Email);
                conexaoSqlServer.AdicionarParametros("@ATIVO", pessoa.Ativo);

                conexaoSqlServer.AdicionarParametros("@STATUS", pessoa.Ativo);
                conexaoSqlServer.AdicionarParametros("@IM", pessoa.Empresa.IM);
                conexaoSqlServer.AdicionarParametros("@TELEFONE", pessoa.Empresa.Telefone);
                conexaoSqlServer.AdicionarParametros("@HORA_INICIO", pessoa.Empresa.HoraAbertura);
                conexaoSqlServer.AdicionarParametros("@HORA_FIM", pessoa.Empresa.HoraFechamento);
                conexaoSqlServer.AdicionarParametros("@IMG_LOGO", pessoa.Empresa.Img_Logo);
                conexaoSqlServer.AdicionarParametros("@ID_SETOR", pessoa.Empresa.idSetor);
                //conexaoSqlServer.AdicionarParametros("@ID_PESSOA", empresa.idPessoa);

                if (opcao == 1)
                {
                    idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspEmpresaAdd").ToString();
                }
                else if (opcao == 2)
                {
                    conexaoSqlServer.AdicionarParametros("@ID", pessoa.Id);
                    idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspEmpresaUpdate").ToString();
                }
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
