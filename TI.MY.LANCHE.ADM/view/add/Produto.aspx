<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="produto.aspx.cs" Inherits="TI.MY.LANCHE.ADM.view.add.Produto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../css/bootstrap/css/bootstrap-grid.min.css" rel="stylesheet" />

    <link href="../../Scripts/css/container.css" rel="stylesheet" />
    <div class="container1">
        <div class="row">
            <div class="form-group col-md-6">
                <h3 class="page-header">Cadastro de Produto
            <div class="form-group col-md-6">
                <asp:Label ID="lblEmpresa" runat="server" Text=""></asp:Label>
                <asp:DropDownList ID="ddlEmpresa" CssClass="form-control" runat="server" class="form-control col-md-3" ControlToValidate="ddlEmpresa" ErrorMessage="Campo Obrigatório." Visible="false" OnSelectedIndexChanged="ddlEmpresa_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
                </h3>

            </div>

        </div>
        <div class="row">
        </div>

        <div class="row">
            <div class="form-group col-md-4">
                <%--<asp:Label runat="server" AssociatedControlID="ddlDepartamento">Departamento</asp:Label>--%>
                <asp:DropDownList ID="ddlDepartamento" CssClass="form-control" runat="server" class="form-control" ControlToValidate="ddlDepartamento" ErrorMessage="Campo Obrigatório.">
                </asp:DropDownList>
            </div>
            <div class="form-group col-md-4">
                <asp:TextBox ID="txtCodBarra" runat="server" placeholder="CODIGO BARRA" class="form-control "></asp:TextBox>
            </div>
            <div class="form-group col-md-3">
                <%--<asp:Label runat="server" AssociatedControlID="chkAtivo">Ativo</asp:Label>--%>
                <asp:CheckBox ID="chkAtivo" CssClass="form-control" runat="server" class="form-control" ErrorMessage="Campo Obrigatório." Text="  Ativo" />
            </div>
        </div>

        <div class="row">
            <div class="form-group col-md-8">
                <label for="Descricao"></label>
                <asp:TextBox ID="txtDescricao" runat="server" placeholder="Descricao do Produto" class="form-control"></asp:TextBox>
            </div>

        </div>

        <div class="row">
            <div class="form-group col-md-4">
                <label for="Unidade">Unidade</label>
                <asp:TextBox ID="txtUnidade" runat="server" placeholder="Unidade" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <label for="Preco">Preco</label>
                <asp:TextBox ID="txtPreco" runat="server" placeholder="$ 0,00" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <label for="Custo">Custo</label>
                <asp:TextBox ID="txtCusto" runat="server" placeholder="$ 0,00" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="form-group col-md-4">
                <label for="DigitaPreco">Granel</label>
                <asp:TextBox ID="txtGranel" runat="server" placeholder="B \ P\ T (Balanca, Digita Preco,Digita Total)" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <label for="Estoque">ESTOQUE</label>
                <asp:TextBox ID="txtEstoque" runat="server" placeholder="Quantidade" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-4">
                <label for="Arquivo">UpLoad</label>
                <asp:FileUpload ID="fupImagem" runat="server" Width="100%" Class="form-control" />
                <br />
            </div>

        </div>
        <div class="row">
            <div class="form-group col-md-4">
                <label for="Composição ou Ingredientes">Ingerdientes ou Composição</label>
                <asp:TextBox ID="txtIngredientes" runat="server" placeholder="Ingredientes, Composição" class="form-control" TextMode="MultiLine" Rows="10"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <%--<asp:Button ID="Sair" class="btn btn-danger" runat="server" Text="Sair" PostBackUrl="~/Index.aspx" OnClick="Sair_Click" />--%>
                <%-- <a href="..Index.aspx" class="btn btn-danger">Sair</a>--%>
                <a href="../../Default.aspx" class="btn btn-danger">Sair</a>
                <asp:Button ID="Add" class="btn btn-success" runat="server" Text="Salvar" OnClick="Add_Click" />
                <asp:Button ID="New" runat="server" Text="Limpa" class="btn btn-warning" />
                <%--<asp:Button ID="Lista" runat="server" Text="Lista" class="btn btn-info" data-toggle="modal" OnClick="../../Default.aspx" />--%>
                <a href="/View/List/Empresa.aspx" class="btn btn-info">Lista</a>

            </div>
        </div>

        <hr />

        <div id="actions" class="row">
            
        </div>
        <br />
    </div>
</asp:Content>
