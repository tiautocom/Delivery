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
    public class ProdutoRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        #region VariaveisConstrutores

        string idRetorno;

        SqlCommand comandSql = new SqlCommand();
        StringBuilder sql = new StringBuilder();
        DataTable dadosTabela = new DataTable();
        #endregion

        //public DataTable Pesquisar(int nomeEmpresa)
        //{
        //    try
        //    {
        //        conexaoSqlServer.LimparParametros();
        //        conexaoSqlServer.AdicionarParametros("@ID_EMPRESA", nomeEmpresa);
        //        DataTable dadosTabela = new DataTable();
        //        dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspListarDepartamentoIdEmpresa");
        //        return dadosTabela;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public DataTable PesquisarNome(string nomeEmpresa)
        //{
        //    try
        //    {
        //        conexaoSqlServer.LimparParametros();
        //        conexaoSqlServer.AdicionarParametros("@NOME_EMPRESA", nomeEmpresa);
        //        DataTable dadosTabela = new DataTable();
        //        dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspListarEmpresaNome");
        //        return dadosTabela;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public DataTable PesquisarId(int idEmpresa)
        //{
        //    try
        //    {
        //        conexaoSqlServer.LimparParametros();
        //        conexaoSqlServer.AdicionarParametros("@ID", idEmpresa);
        //        DataTable dadosTabela = new DataTable();
        //        dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspListarEmpresaId");
        //        return dadosTabela;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        #region Add_Update
        public string AddProduto(Producto producto, int opcao)
        {
            try
            {
                //0PCAO 1=CADASTRAR - 2=ALTERAR
                conexaoSqlServer.LimparParametros();

                // conexaoSqlServer.AdicionarParametros("@Tipo", opcao);
                conexaoSqlServer.AdicionarParametros("@COD_BARRA", producto.codBarra);
                conexaoSqlServer.AdicionarParametros("@DESCRICAO", producto.descricao);
                conexaoSqlServer.AdicionarParametros("@UNID", producto.unidade);
                conexaoSqlServer.AdicionarParametros("@PRECO", producto.Departamento_Produto.preco);
                conexaoSqlServer.AdicionarParametros("@CUSTO", producto.Departamento_Produto.custo);
                conexaoSqlServer.AdicionarParametros("@ESTOQUE", producto.Departamento_Produto.estoque);

                conexaoSqlServer.AdicionarParametros("@ID_DEPARTAMENTO", producto.Departamento_Produto.idDepartamento);
                conexaoSqlServer.AdicionarParametros("@ID_EMPRESA", producto.Departamento_Produto.idEmpresa);
                conexaoSqlServer.AdicionarParametros("@GRANEL", producto.Departamento_Produto.granel);
                conexaoSqlServer.AdicionarParametros("@ATIVO", producto.Departamento_Produto.ativo);
                conexaoSqlServer.AdicionarParametros("@INGREDIENTES", producto.ingredientes);
                conexaoSqlServer.AdicionarParametros("@DATA", producto.dtCadastro);
                conexaoSqlServer.AdicionarParametros("@URL", producto.urlFoto);
              
                if (opcao == 1)
                {
                    idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProdutoAdd").ToString();
                }
                else if (opcao == 2)
                {
                    conexaoSqlServer.AdicionarParametros("@ID", producto.id);
                    idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProdutoUpdate").ToString();
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
