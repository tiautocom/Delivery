<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TI.MY.LANCHE.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />

    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/animate/animate.css" />
    <!--===============================================================================================-->

    <link href="vendor/css-hamburgers/hamburgers.css" rel="stylesheet" />
    <link href="vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" />

    <link href="vendor/select2/select2.min.css" rel="stylesheet" />
    <link href="csss/main.css" rel="stylesheet" />
    <link href="csss/util.css" rel="stylesheet" />

    <script>
        window.addEventListener("load", function (event) {

            //let nomeUsuario = localStorage.getItem("nomeUsuario", nome);
            //let celularUsuario = localStorage.getItem("celularUsuario", celular);

            var celUsuario = getCookie("nomeUsuario");

            var url = sessionStorage.getItem('urlLogin');

            if (nomeUsuario = null) {
                window.location.href = url;
            } else {
            }
        });
    </script>

</head>
<body>

    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <div class="login100-pic js-tilt" data-tilt>
                    <img src="images/images.png" alt="IMG" />
                </div>

                <form id="form1" runat="server" class="login100-form validate-form" />
                <span class="login100-form-title">Meu Primeiro Acesso
                </span>

                <div class="wrap-input100 validate-input" data-validate="Valid email is required: ex@abc.xyz">
                    <input class="input100" id="nome" type="text" placeholder="Nome Usuário" />
                    <span class="focus-input100"></span>
                    <span class="symbol-input100">
                        <i class="fa fa-user" aria-hidden="true"></i>
                    </span>
                </div>

                <div class="wrap-input100 validate-input" data-validate="Password is required">
                    <input class="input100" id="celular" type="text" name="pass" placeholder="Nº Celular" />
                    <span class="focus-input100"></span>
                    <span class="symbol-input100">
                        <i class="fa fa-phone" aria-hidden="true"></i>
                    </span>
                </div>

                <div class="container-login100-form-btn">
                    <button class="login100-form-btn" onclick="logar()">
                        Login
                    </button>
                </div>

                <div class="text-center p-t-12">
                    <span class="txt1">Forgot
                    </span>
                    <a class="txt2" href="#">Username / Password?
                    </a>
                </div>

                <div class="text-center p-t-136">
                    <a class="txt2" href="#">Create your Account
							<i class="fa fa-long-arrow-right m-l-5" aria-hidden="true"></i>
                    </a>
                </div>

            </div>
        </div>
    </div>

    <!--===============================================================================================-->
    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/bootstrap/js/popper.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/tilt/tilt.jquery.min.js"></script>
    <script>
        $('.js-tilt').tilt({
            scale: 1.1
        })

        function logar() {
            var nome = window.document.getElementById("nome").value;
            var celular = window.document.getElementById("celular").value;

            if (nome === "") {
                alert("Campo Nome do Usuário é Obrigatório");
            } else if (celular === "") {
                alert("Campo Celular do Usuário é Obrigatório");
            } else {
                localStorage.setItem("nomeUsuario", nome);
                localStorage.setItem("celularUsuario", celular);

                setCookie("nomeUsuario", nome, '13 Mai 2054 12:00:00')

                var data = sessionStorage.getItem('urlLogin');

                if (data == null) {
                    window.location.href = "index.html";
                } else {
                    window.location.href = data;
                }
            }
        }

        function setCookie(name, value, duration) {
            var cookie = name + "=" + escape(value) +
            ((duration) ? "; duration=" + duration : "");

            document.cookie = cookie;
        }

        function deleteCookie(name) {
            if (getCookie(name)) {
                document.cookie = name + "=" + "; expires=Thu, 01-Jan-70 00:00:01 GMT";
            }
        }

        function getCookie(name) {
            var nameEQ = name + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') c = c.substring(1, c.length);
                if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
            }
            return null;
        }


    </script>
    <!--===============================================================================================-->
    <script src="js/main.js"></script>

</body>
</html>
