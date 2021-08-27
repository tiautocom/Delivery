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

        public DataTable ListProdutoEmpresaId(int idEmpresa)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_EMPRESA", idEmpresa);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspListarDepartamentoIdEmpresa");
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ListProdutoEmpresaId(int idEmpresa, int idDepartamento)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_EMPRESA", idEmpresa);
                conexaoSqlServer.AdicionarParametros("@ID_DEPARTAMENTO", idDepartamento);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspListarDepartamentoProdutoIdEmpresa");
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ListProdutoEmpresaId(string idEmpresa, string idProduto)
        {
            try
            {
                conexaoSqlServer.LimparParametros();
                conexaoSqlServer.AdicionarParametros("@ID_EMPRESA", idEmpresa);
                conexaoSqlServer.AdicionarParametros("@ID_PRODUTO", idProduto);
                DataTable dadosTabela = new DataTable();
                dadosTabela = conexaoSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspListarProdutoIdEmpresa");
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable PesquisaProdutoId(string idEmpresa)
        {
            throw new NotImplementedException();
        }

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
                    conexaoSqlServer.AdicionarParametros("@ID_PRODUTO", producto.id);
                    idRetorno = conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProdutoUpdate").ToString();
                }
                return idRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        #region UpdateAtivarDesativar
        public int SuspenderProduto(Producto producto, int opcao)
        {
            try
            {
                conexaoSqlServer.AdicionarParametros("@ATIVO", producto.Departamento_Produto.ativo);
                conexaoSqlServer.AdicionarParametros("@ID_PRODUTO", producto.id);
                conexaoSqlServer.AdicionarParametros("@ID_EMPRESA", producto.Departamento_Produto.idEmpresa);

                return Convert.ToInt32(conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProdutoAtivarDesativar").ToString());
            }
            catch (Exception EX)
            {

                throw;
            }
        }

        public int AtivarProduto(Producto producto, int v)
        {
            try
            {
                conexaoSqlServer.AdicionarParametros("@ATIVO", producto.Departamento_Produto.ativo);
                conexaoSqlServer.AdicionarParametros("@ID_PRODUTO", producto.id);
                conexaoSqlServer.AdicionarParametros("@ID_EMPRESA", producto.Departamento_Produto.idEmpresa);

                return Convert.ToInt32(conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspProdutoAtivarDesativar").ToString());
            }
            catch (Exception EX)
            {

                throw;
            }
        }
        #endregion

        #endregion

    }
}
