<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="empresa.aspx.cs" Inherits="TI.MY.LANCHE.ADM.view.add.empresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../css/bootstrap/css/bootstrap-grid.min.css" rel="stylesheet" />

    <link href="../../Scripts/css/container.css" rel="stylesheet" />
    <div class="container1">
        <div class="row">
            <div class="form-group col-md-6">
                <h3 class="page-header">Cadastro de Empresa </h3>
            </div>
        </div>
        <div class="row">

            <div class="form-group col-md-4">
                <label for="Fantasia" cssclass="col-md-2 control-label">Nome Fantasia </label>
                <asp:TextBox ID="Fantasia" runat="server" placeholder="Digite o Nome Fantasia" class="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <label for="Telefone" cssclass="col-md-2 control-label">Telefone</label>
                <asp:TextBox ID="txtFone" runat="server" placeholder="99 99999-9999" class="form-control" TextMode="Phone"></asp:TextBox>
            </div>


            <div class="form-group col-md-4">
                <label for="Email" cssclass="col-md-2 control-label">E-mail</label>
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Digite o E-Mail da Empresa" class="form-control" TextMode="Email"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-4">
                <label for="Cnpj">CNPJ / CPF</label>
                <asp:TextBox ID="txtCnpj" runat="server" placeholder="00.000.000/0000-00" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <label for="Cnpj">HORA ABERTURA</label>
                <asp:TextBox ID="txtHoraAbertura" runat="server" placeholder="00:00:00" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <label for="Cnpj">HORA FECHAMENTO</label>
                <asp:TextBox ID="txtHoraFechamnto" runat="server" placeholder="00:00:00" class="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="row">

            <div class="form-group col-md-4">
                <div>
                    <asp:FileUpload ID="fupImagem" runat="server" Width="100%" CssClass="form-control" />
                    <br />
                </div>
            </div>

            <div class="form-group col-md-4">
                <%--<asp:Label runat="server" AssociatedControlID="ddlAtivo">Ativação</asp:Label>--%>

                <asp:DropDownList ID="ddlAtivo" CssClass="form-control" runat="server" Width="30%" class="form-control" ControlToValidate="ddlAtivo" ErrorMessage="Campo Obrigatório.">
                    <asp:ListItem Value="true">Ativo</asp:ListItem>
                    <asp:ListItem Value="false">Inativo</asp:ListItem>
                </asp:DropDownList>

            </div>
        </div>

        <hr />

        <div id="actions" class="row">
            <div class="col-md-12">
                <%--<asp:Button ID="Sair" class="btn btn-danger" runat="server" Text="Sair" PostBackUrl="~/Index.aspx" OnClick="Sair_Click" />--%>
                <%-- <a href="..Index.aspx" class="btn btn-danger">Sair</a>--%>
                <a href="../../Default.aspx" class="btn btn-danger">Sair</a>
                <asp:Button ID="Add" class="btn btn-success" runat="server" Text="Salvar" OnClick="Add_Click" />
                <asp:Button ID="New" runat="server" Text="Limpa" class="btn btn-warning" OnClick="New_Click" />
                <%--<asp:Button ID="Lista" runat="server" Text="Lista" class="btn btn-info" data-toggle="modal" OnClick="../../Default.aspx" />--%>
                <a href="/View/List/Empresa.aspx" class="btn btn-info">Lista</a>

            </div>
        </div>
        <br />
    </div>
</asp:Content>
