<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="departamentonovo.aspx.cs" Inherits="TI.MY.LANCHE.ADM.view.add.departamentonovo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../css/bootstrap/css/bootstrap-grid.min.css" rel="stylesheet" />

    <link href="../../Scripts/css/container.css" rel="stylesheet" />
    <div class="container1">
        <div class="row">
            <div class="form-group col-md-6">
                <h3 class="page-header">Cadastro de Departamento 
                    <asp:Label ID="lblIdDepartamento" runat="server" Text=""></asp:Label>
                      <asp:Label ID="lblEmpresa" runat="server" Text=""></asp:Label>
                </h3>
            </div>

        </div>

        <div class="row">
            <div class="form-group col-md-6">
                <label for="Descricao"> Departamento</label>
                <asp:TextBox ID="txtDescricao" runat="server" placeholder="Descricao do Departamento" class="form-control"></asp:TextBox>
            </div>
             <div class="form-group col-md-6">
                <label for="Arquivo">UpLoad</label>
                <asp:FileUpload ID="fupImagem" runat="server" Width="100%" Class="form-control" />
                <br />
            </div>
        </div>
        
        <div class="row">
      
            <div class="col-md-4">
                <%--<asp:Button ID="Sair" class="btn btn-danger" runat="server" Text="Sair" PostBackUrl="~/Index.aspx" OnClick="Sair_Click" />--%>
                <%-- <a href="..Index.aspx" class="btn btn-danger">Sair</a>--%>
                <a href="../../Default.aspx" class="btn btn-danger">Sair</a>
                <asp:Button ID="Add" class="btn btn-success" runat="server" Text="Salvar" OnClick="Add_Click"  />
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
