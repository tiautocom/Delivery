<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="deletelistprod.aspx.cs" Inherits="TI.MY.LANCHE.ADM.view.list.deletelistprod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="input-group mb-12">
        <h2>
            <asp:Label ID="lblEmpresa" runat="server" Text=""></asp:Label>
            <b>Lista de Produtos </b>
            <%--<asp:TextBox ID="txtPesquisar" runat="server" Width="250px" placeholder="Descrição do Produto" AutoPostBack="false" class="form-control" OnTextChanged="Pesquisar_TextChanged" style="left: 0px; top: 0px">
            </asp:TextBox>--%>
            <asp:DropDownList ID="ddlDepartamento" CssClass="form-control" runat="server" class="form-control" ControlToValidate="ddlDepartamento" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" Style="left: 0px; top: 0px">
            </asp:DropDownList>
            <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" />
        </h2>

        <%-- <asp:TextBox ID="Pesquisar" runat="server" placeholder="Pesquisa" Style="height: 34px; padding: 6px 12px; font-size: 14px; line-height: 1.428571429; color: #555555; vertical-align: middle; background-color: #ffffff; background-image: none; border: 1px solid #cccccc; border-radius: 4px; -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075); box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075); -webkit-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s; transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s; margin-right: 0px;" Width="275px"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="Enter" class="btn btn-primary" />--%>
    </div>

    <div class="table-responsive">
        <asp:GridView ID="gdvProduto" runat="server" Width="100%" CssClass="table table-striped" AutoGenerateColumns="False" ShowHeader="False" HorizontalAlign="Center" UseAccessibleHeader="False" OnRowCommand="gdvProduto_RowCommand" DataKeyNames="ID_PRODUTO, ATIVO">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lbId" runat="server" Text='<%# Bind("ID_PRODUTO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lbDescricao" runat="server" Text='<%# Bind("PRODUTO") %>' Width="200px"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblFantasia" runat="server" Text='<%# Bind("PRECO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField Visible="true" ShowHeader="true">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="cb101" AutoPostBack="false" Checked='<%# Eval("Ativo").ToString()=="1" ? true : false %>' Enabled='<%#(String.IsNullOrEmpty(Eval("Ativo").ToString()) ? false: true) %>' />
                    </ItemTemplate>
                </asp:TemplateField>


                <%--     <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSel" runat="server" Text='<%# Bind("ATIVO") %>'></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>--%>

                <asp:BoundField DataField="CPF_CNPJ" Visible="False" />

                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnExcluir" runat="server" Width="100%" CssClass="btn btn-danger" Text="Suspender" ToolTip="Suspender Produto" Font-Size="Smaller" CommandName="DELETAR" CommandArgument='<%#  Eval("ID_PRODUTO") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <EditRowStyle BorderStyle="None" Font-Size="X-Large" />
            <RowStyle BorderStyle="Inset" Wrap="False" />
        </asp:GridView>
    </div>


    <div id="actions" class="row">
        <div class="col-md-12">
            <asp:Button ID="Sair" class="btn btn-danger" runat="server" Text="Sair" PostBackUrl="~/Index.aspx" OnClick="Sair_Click" />
            <asp:Button ID="SuspenderSelecao" runat="server" Text="Suspender Selecao" class="btn btn-success" OnClick="SuspenderSelecao_Click" />

        </div>
    </div>
    <hr />
</asp:Content>
