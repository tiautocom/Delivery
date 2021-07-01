<%@ Page Title="Lista de Pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pedidos.aspx.cs" Inherits="TI.MY.LANCHE.ADM.view.list.pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        // Este evendo é acionado após o carregamento da página
        jQuery(window).load(function() {
            //Após a leitura da pagina o evento fadeOut do loader é acionado, esta com delay para ser perceptivo em ambiente fora do servidor.
            jQuery("#loader").delay(2000).fadeOut("slow");

            alert("arou");
        });
    </script>

    <h2><b>Lista de Empresa
        <asp:Literal ID="literalName" runat="server"></asp:Literal>
    </b>
    </h2>
    <div class="input-group mb-12">
        <asp:TextBox ID="txtPesquisar" runat="server" Width="250px" placeholder="Numero Pedido" AutoPostBack="false" class="form-control"></asp:TextBox>
        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" />
    </div>
    <br />
    <div class="input-group mb-12">
        <div class="table-responsive">
            <asp:GridView ID="gdvPedido" runat="server" Width="100%" CssClass="table table-striped" AutoGenerateColumns="False" ShowHeader="False" HorizontalAlign="Center" UseAccessibleHeader="False">
                <Columns>
                    <asp:TemplateField Visible="true" HeaderText="Numero">
                        <ItemTemplate>
                            <asp:Label ID="lbId" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lbDescricao" runat="server" Text='<%# Bind("NUMERO") %>' Width="120px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lbDescricao" runat="server" Text='<%# Bind("TIPO_PAGTO") %>' Width="120px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lbDescricao" runat="server" Text='<%# Bind("STATUS_PEDIDO") %>' Width="500px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField Visible="false" ShowHeader="true">
                        <ItemTemplate>
                            <asp:Label ID="lblFantasia" runat="server" Text='<%# Bind("RECIBO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CPF_CNPJ" Visible="False" />

                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btnImprimirPEdido" runat="server" Width="100%" BorderStyle="Double" CssClass="btn btn-info" Text="Imprimir Pedido" ToolTip="Imprimir Pedidos" Font-Size="Smaller" CommandName="Fechar" CommandArgument='<%#Eval("ID") %>' />
                        </ItemTemplate>
                        <ItemStyle Font-Size="Smaller" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btnFecharPedido" runat="server" BorderStyle="None" Width="100%" CssClass="btn btn-warning" Text="Fechar Pedido" Font-Size="Smaller" />
                            <%--         <asp:Button ID="btnEditar" runat="server" BorderStyle="None" Width="100%" CssClass="btn btn-warning" Text="Editar" Font-Size="Smaller" CommandName="EDITAR" CommandArgument='<%#Eval("ID") %>' CommandText='<%#Eval("DESCRICAO") %>' />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BorderStyle="None" Font-Size="X-Large" />
                <RowStyle BorderStyle="Inset" Wrap="False" />
            </asp:GridView>
        </div>
    </div>


    <div id="actions" class="row">
        <div class="col-md-12">
            <asp:Button ID="Sair" class="btn btn-danger" runat="server" Text="Sair" PostBackUrl="~/Index.aspx" />
        </div>
    </div>
    <hr />

</asp:Content>
