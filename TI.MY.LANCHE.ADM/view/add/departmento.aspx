<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="departmento.aspx.cs" Inherits="TI.MY.LANCHE.ADM.view.add.departmento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="input-group mb-12">
        <h2>
            <asp:Label ID="lblEmpresa" runat="server" Text=""></asp:Label>
            <b>Lista de Departamento </b>
            <%--<asp:TextBox ID="txtPesquisar" runat="server" Width="250px" placeholder="Descrição do Produto" AutoPostBack="false" class="form-control" OnTextChanged="Pesquisar_TextChanged" style="left: 0px; top: 0px">
            </asp:TextBox>--%>
            <%--<asp:DropDownList ID="ddlDepartamento" CssClass="form-control" runat="server" class="form-control" ControlToValidate="ddlDepartamento" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
            </asp:DropDownList>--%>
            <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" />
        </h2>

        <%-- <asp:TextBox ID="Pesquisar" runat="server" placeholder="Pesquisa" Style="height: 34px; padding: 6px 12px; font-size: 14px; line-height: 1.428571429; color: #555555; vertical-align: middle; background-color: #ffffff; background-image: none; border: 1px solid #cccccc; border-radius: 4px; -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075); box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075); -webkit-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s; transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s; margin-right: 0px;" Width="275px"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="Enter" class="btn btn-primary" />--%>
    </div>

    <div class="table-responsive">
        <div class="col-md-12">

            <div class="col-md-6">
                <%--<asp:CheckBoxList ID="cklDepartamento" runat="server"></asp:CheckBoxList>--%>
                <asp:GridView ID="gdvDepartamento" runat="server" Width="100%" CssClass="table table-striped" AutoGenerateColumns="False" ShowHeader="False" HorizontalAlign="Center" UseAccessibleHeader="False" DataKeyNames="ID_DEPARTAMENTO, DESCRICAO_DEPARTAMENTO, ATIVO" OnRowCommand="gdvDepartamento_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lbId" runat="server" Text='<%# Bind("ID_DEPARTAMENTO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

          <%--              <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lbDescricao" runat="server" Text='<%# Bind("DESCRICAO_DEPARTAMENTO") %>' Width="200px"><%# Eval("Descricao")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField Visible="true" ShowHeader="true">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="check" AutoPostBack="false" Checked='<%# Eval("Ativo").ToString()=="1" ? true : false %>' Enabled='<%#(String.IsNullOrEmpty(Eval("Ativo").ToString()) ? false: true) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <%--                        <asp:Button ID="btnAtivar" runat="server" Width="100%" CssClass="btn btn-success" Text="CADASTRAR" ToolTip="Ativar Departamento" Font-Size="Smaller" CommandName="CADASTRAR" CommandArgument='<%# Eval("ID_DEPARTAMENTO") %>'  />--%>
                                <asp:Button ID="lblDescricao" Width="100%" runat="server" CssClass="btn btn-primary" Text='<%# Eval("DESCRICAO_DEPARTAMENTO") %>' CommandName="CADASTRAR" CommandArgument='<%# Container.DataItemIndex%>'></asp:Button>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <EditRowStyle BorderStyle="None" Font-Size="X-Large" />
                    <RowStyle BorderStyle="Inset" Wrap="False" />
                </asp:GridView>
            </div>
            <div class="col-md-6">

                <%--<asp:CheckBoxList ID="cklDepEmpresa" runat="server"></asp:CheckBoxList>--%>
                <asp:GridView ID="gdvDepartamentoEmpresa" runat="server" Width="100%" CssClass="table table-striped" AutoGenerateColumns="False" ShowHeader="False" HorizontalAlign="Center" UseAccessibleHeader="False" DataKeyNames="ID_DEPARTAMENTO, ATIVO" OnRowCommand="gdvDepartamentoEmpresa_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lbId" runat="server" Text='<%# Bind("ID_DEPARTAMENTO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lbDescricao" runat="server" Text='<%# Bind("DESCRICAO_DEPARTAMENTO") %>' Width="200px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField Visible="true" ShowHeader="true">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="check" AutoPostBack="false" Checked='<%# Eval("Ativo").ToString()=="1" ? true : false %>' Enabled='<%#(String.IsNullOrEmpty(Eval("Ativo").ToString()) ? false: true) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="btnDesativar" runat="server" Width="100%" CssClass="btn btn-danger" Text="DESATIVAR" ToolTip="Ativar Departamento" Font-Size="Smaller" />
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
                <asp:Button ID="btnNovo" runat="server" class="btn btn-info" Text="Novo Departamento" />
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar Selecção" class="btn btn-success" />
                <asp:Button ID="btnSair" runat="server" class="btn btn-danger" Text="Sair" PostBackUrl="~/Index.aspx" />
            </div>
        </div>

    </div>
    <hr />
</asp:Content>
