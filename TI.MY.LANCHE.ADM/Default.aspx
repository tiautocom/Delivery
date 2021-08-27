<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TI.MY.LANCHE.ADM._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>
            <asp:Label ID="lblEmpresa" runat="server" Text="EMPRESA"></asp:Label>
        </h1>
        <p class="lead">CONFIRA NOSSAS PROMOÇOES !!! </p>
        <p><a href="" class="btn btn-primary btn-lg">PROMOÇÕES&raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <asp:Button ID="btnCadastro" runat="server" Text="Cadastro &raquo;" class="btn btn-primary btn-lg " OnClick="btnCadastro_Click" />
        </div>
        <div class="col-md-4">
            <p><a href="http://adm.idisque.com.br" class="btn btn-primary btn-lg">Configuração e Ajustes &raquo;</a></p>

        </div>
        <div class="col-md-4">
            <p><a href="http://adm.idisque.com.br" class="btn btn-primary btn-lg">Mais &raquo;</a></p>
        </div>
    </div>

</asp:Content>
