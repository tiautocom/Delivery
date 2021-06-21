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
    public class PedidoRegraNegocios
    {
        Conexao conexaoSqlServer = new Conexao();

        public int idEmpresa = 0;

        public string Salvar(Pedidos pedido)
        {
            try
            {
                string dataBarsilia = ObterHorarioBrasilia().ToString();
                conexaoSqlServer.LimparParametros();

                conexaoSqlServer.AdicionarParametros("@NUMERO", pedido.numeroPedido.Trim());
                conexaoSqlServer.AdicionarParametros("@ID_EMPRESA", pedido.idEmpresa);
                conexaoSqlServer.AdicionarParametros("@TIPO_PGTO", pedido.tipoPagamento);
                conexaoSqlServer.AdicionarParametros("@DATA", dataBarsilia);
                conexaoSqlServer.AdicionarParametros("@TAXA_ENTREGA", Convert.ToDecimal(pedido.taxaEntrega));
                conexaoSqlServer.AdicionarParametros("@TROCO_PARA", Convert.ToDecimal(pedido.trocoPara));
                conexaoSqlServer.AdicionarParametros("@OBS_PEDIDO", "");
                conexaoSqlServer.AdicionarParametros("@FECHADO", false);
                conexaoSqlServer.AdicionarParametros("@STATUS_PEDIDO", "PEDIDO ACEITO");
                conexaoSqlServer.AdicionarParametros("@SOMA_TOTAL", Convert.ToDecimal(pedido.total));
                conexaoSqlServer.AdicionarParametros("@TAMANHO", "");
                conexaoSqlServer.AdicionarParametros("@TELEFONE_CLIENTE", pedido.telefone);
                conexaoSqlServer.AdicionarParametros("@RECIBO", pedido.pedidotexto);

                return conexaoSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspPedidosSalvar").ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DateTime ObterHorarioBrasilia()
        {
            DateTime DateTimeUtc = DateTime.UtcNow;

            TimeZoneInfo TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");//(GMT-03:00) Brasília

            DateTime DateTimeBrasilia = TimeZoneInfo.ConvertTimeFromUtc(DateTimeUtc, TimeZoneInfo);

            return DateTimeBrasilia;
        }
    }
}
