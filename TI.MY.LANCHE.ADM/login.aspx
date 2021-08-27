<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TI.MY.LANCHE.ADM.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <link href="CSS/login.css" rel="stylesheet" />

    <title>Login</title>

</head>
<body>
    <form id="form1" runat="server">
        <div class="sidenav" style="background-image: url()">
            <div class="login-main-text">
                <h2>Adm - Login</h2>
                <p>Bem vindo ao Sistema de Gerenciamento e Cadastro.</p>
                <p>iDisque</p>
                <p>Entre ou registre-se aqui para acessar</p>
            </div>
        </div>
        <div class="main">
            <div class="col-md-6 col-sm-12">
                <div class="login-form">

                    <div class="form-group">
                        <label>Entre com E-Mail ou Celular</label>
                        <asp:TextBox ID="txtEmailCel" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>Senha</label>
                        <asp:TextBox ID="txtSenha" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                    </div>

                    <asp:Button ID="btnLogar" runat="server" Text="Logar" CssClass="btn btn-black" OnClick="btnLogar_Click" />
                    <asp:Button ID="btnRegistro" runat="server" Text="Registro" CssClass="btn btn-secondary" />

                    <p class="text-danger">
                        <asp:Literal ID="FailureText" runat="server" />
                    </p>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
