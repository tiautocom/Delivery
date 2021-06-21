<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="empresa.aspx.cs" Inherits="TI.MY.LANCHE.ADM.view.list.empresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container alert-info">

        <div class="input-group mb-12">
            <h2><b>Lista de Empresa </b>
                <asp:TextBox ID="Pesquisar" runat="server" Width="250px" placeholder="Nome Empresa" AutoPostBack="false" class="form-control" OnTextChanged="Pesquisar_TextChanged">
                </asp:TextBox>
                <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" OnClick="btnPesquisar_Click" />
            </h2>

            <%-- <asp:TextBox ID="Pesquisar" runat="server" placeholder="Pesquisa" Style="height: 34px; padding: 6px 12px; font-size: 14px; line-height: 1.428571429; color: #555555; vertical-align: middle; background-color: #ffffff; background-image: none; border: 1px solid #cccccc; border-radius: 4px; -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075); box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075); -webkit-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s; transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s; margin-right: 0px;" Width="275px"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="Enter" class="btn btn-primary" />--%>
        </div>

        <div class="table-responsive">
            <asp:GridView ID="gdvEmp" runat="server" Width="100%" CssClass="table table-striped" AutoGenerateColumns="False" ShowHeader="False" HorizontalAlign="Center" UseAccessibleHeader="False" OnRowCommand="gdvEmp_RowCommand" OnSelectedIndexChanged="gdvEmp_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbId" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lbNomeRazao" runat="server" Text='<%# Bind("NOME_RAZAO") %>' Width="200px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblFantasia" runat="server" Text='<%# Bind("FANTASIA") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CPF_CNPJ" Visible="False" />
                    <%--<asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("EMAIL") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="IM" Visible="False" />
                    <asp:BoundField DataField="RG_IE" Visible="False" />
                    <asp:BoundField DataField="CEP" Visible="False" />
                    <asp:BoundField DataField="CIDADE" Visible="False" />
                    <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("LOGRADOURO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="NUMERO" Visible="False" />
                    <asp:BoundField DataField="UF" Visible="False" />
                    <asp:BoundField DataField="CONTATO" Visible="False" />
                    <asp:BoundField DataField="OBSERVACAO" Visible="False" />
                    <asp:BoundField DataField="RAMAL" Visible="False" />
                    <asp:BoundField DataField="RESPONSAVEL" Visible="False" />
                    <asp:BoundField DataField="SETOR" Visible="False" />
                    <asp:BoundField DataField="TELEFONE" Visible="False" />--%>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btnDetalhe" runat="server" Width="100%" BorderStyle="Double" CssClass="btn btn-info" Text="Detalhes" ToolTip="Detalhes da Empresa" Font-Size="Smaller" CommandName="EDITAR" CommandArgument='<%#  Eval("ID") %>' />
                        </ItemTemplate>
                        <ItemStyle Font-Size="Smaller" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" BorderStyle="None" Width="100%" CssClass="btn btn-warning" Text="Editar" Font-Size="Smaller" CommandName="EDITAR" CommandArgument='<%#  Eval("ID") %>' CommandText='<%#  Eval("NOME_RAZAO") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btnExcluir" runat="server"  Width="100%" CssClass="btn btn-danger" Text="Excluir" ToolTip="Excluir Dados Empresa" Font-Size="Smaller" CommandName="DELETAR" CommandArgument='<%#  Eval("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <EditRowStyle BorderStyle="None" Font-Size="X-Large" />
                <RowStyle BorderStyle="Inset" Wrap="False" />
            </asp:GridView>
        </div>


        <div id="actions" class="row">
            <div class="col-md-12">
                <asp:Button ID="Sair" class="btn btn-danger" runat="server" Text="Sair" PostBackUrl="~/Index.aspx" />
                <asp:Button ID="Novo" runat="server" Text="Nova Empresa" class="btn btn-success" PostBackUrl="~/View/Add/Empresa.aspx"  />

            </div>
        </div>
        <hr />
    </div>
</asp:Content>
