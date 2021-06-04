<%@ Page Title="Bem Vindo a Pastelaria Alameda" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TI.MY.LANCHE.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css" />

    <asp:PlaceHolder ID="iFrameScript" runat="server" />
    <style>
        .strong {
            color: red;
        }

        dados {
            width: 100%;
            color: red;
        }

        .material-icons {
            font-family: 'Material Icons';
            font-weight: normal;
            font-style: normal;
            font-size: 40px;
            line-height: 1;
            letter-spacing: normal;
            text-transform: none;
            display: inline-block;
            white-space: nowrap;
            word-wrap: normal;
            direction: ltr;
            -webkit-font-feature-settings: 'liga';
            -webkit-font-smoothing: antialiased;
        }

        footer {
            position: fixed;
            bottom: 0;
            background-color: #d34000;
            color: #FFF;
            width: 100%;
            height: 90px;
            text-align: center;
            line-height: 100px;
            margin-top: -19px;
            margin-left: -20px;
            width: 200%;
        }

        .whatsapp-link {
            position: fixed;
            width: 60px;
            height: 60px;
            bottom: 40px;
            right: 40px;
            background-color: #25d366;
            color: #fff;
            border-radius: 50px;
            text-align: center;
            font-size: 30px;
            box-shadow: 1px 1px 2px #888;
            z-index: 1000;
        }

        .fa-whatsapp {
            margin-top: 16px;
        }
    </style>

    <script>
        //window.addEventListener("load", function (event) {

        //    var numPedido = Number(localStorage.getItem("numPedido", numPedido));
        //    var numCelularCliente = Number(localStorage.getItem("numCelular", numPedido));

        //    if (numCelularCliente === '') {
        //        if (numPedido == 0) {
        //            numPedido = 1;
        //        }

        //        localStorage.getItem("numPedido", numPedido);
        //        localStorage.setItem("numPedido", numPedido);

        //        alert(numPedido);
        //    } else {
        //        window.location.href = "Login.aspx";
        //    }
        //});

        function aletrarNumPedido() {

            var numPedido = Number(localStorage.getItem("numPedido", numPedido));

            if (numPedido == 0) {
                numPedido = 1;
            }

            numPedido++;

            localStorage.getItem("numPedido", numPedido);
            localStorage.setItem("numPedido", numPedido);
            alert(numPedido);
        }

    </script>

    <div class="shadowBox">

        <div class="page-container">
            <div class="container">
                <h6>
                    <strong>
                        <asp:Literal ID="Departamentos" runat="server" />
                    </strong>
                </h6>

                <div class="row">
                    <asp:PlaceHolder ID="iFrameIndex" runat="server" />
                </div>
            </div>

      <%--      <a class="whatsapp-link" href="https://api.whatsapp.com/send?phone=5516%988285285&text=*Pedido%20rhEBeYDin*%20-%20*Pastelaria%Alameda*%0A---------------------------%0A%0A*4x%20Coca-cola%201%2C5L%20R%24%2020%2C00*%20_c%C3%B3d.%2045XV_%20%0A*1x%20Mega%20Burguer*%20_c%C3%B3d.%205RYK_%20%0A%20%E2%80%A2%20Frances%20%0A%0A*Subtotal%3A*%20R%24%2020%2C00%0A*Taxa%20de%20entrega%3A*%20Gr%C3%A1tis%0A*Taxa%20de%20embalagem%3A*%20Gr%C3%A1tis%0A%0A*Total%3A*%20R%24%2020%2C00%0A%0A---------------------------%0A*Retirada%20no%20local*%0A%0A*Pagamento%3A*%20Dinheiro%0A%0AAcompanhe%20seu%20pedido%20em%3A%0Aapp.qrmenus.com.br%2Fdemo-burguer%2Forder%2FrhEBeYDin" target="_blank">
                <i class="fa fa-whatsapp"></i>
            </a>--%>
        </div>

        <script>

            function AddCarrinho(produto, qtd, valor, posicao, obs) {
                localStorage.setItem("produto" + posicao, produto);
                localStorage.setItem("quantidade" + posicao, qtd);
                valor = valor * qtd;
                localStorage.setItem("valor" + posicao, valor);

                if ((obs === "") || (obs === null)) {
                    localStorage.setItem("Obs" + posicao, "");
                } else {
                    localStorage.setItem("Obs" + posicao, obs)
                }

                alert("Produto adicionado ao carrinho!\n\nValor Total Pedido de R$ " + valor.toFixed(2));

                window.location.href = "Default.aspx";
            }

            function IrCarrinho() {

                let nomeUsuario = localStorage.setItem("valor" + 0, valor);

                if (nomeUsuario.length > 0) {
                    window.location.href = "VerCarrinho.aspx";
                }
            };

            //function retornoTotal() {
            //    let valortotal = document.querySelector("#total");
            //    return moedaParaFloat(valortotal.innerHTML);
            //}

            //function escreverTotal(_valor) {
            //    let valortotalEsc = document.querySelector("#total");
            //    valortotalEsc.innerHTML = floatParaMoeda(_valor);
            //}

            //function calcularTotaProdutos() {

            //    let todoProdutos = document.querySelectorAll('.plus1');
            //    let todaQuantidade = document.querySelectorAll('.quant1');

            //    // alert(todoProdutos);

            //    let totaProduto = 0;

            //    for (let i = 0; i < todoProdutos.length; i++) {
            //        let umPreoc = moedaParaFloat(todoProdutos[i].innerHTML);
            //        let umaQtde = moedaParaFloat(todaQuantidade[i].value);
            //        let subtotal = umPreoc * umaQtde;

            //        totaProduto += subtotal;
            //    }

            //    return totaProduto;
            //}

            //function qtdeMudou() {

            //    escreverTotal(calcularTotaProdutos());
            //}

            //function aoCarregarPagina() {
            //    let quantidade = document.querySelectorAll('.quantidade');

            //    for (let x = 0; x < quantidade.length; x++) {
            //        quantidade[x].onchange = (function () {
            //            qtdeMudou();
            //        });
            //    }
            //}

            //window.onload = (function () {
            //    //  alert("aqui");
            //    aoCarregarPagina()
            //    qtdeMudou()
            //});

            function moeda(a, e, r, t) {
                alert("moeda");
                let n = ""
                  , h = j = 0
                  , u = tamanho2 = 0
                  , l = ajd2 = ""
                  , o = window.Event ? t.which : t.keyCode;
                if (13 == o || 8 == o)
                    return !0;
                if (n = String.fromCharCode(o),
                -1 == "0123456789".indexOf(n))
                    return !1;
                for (u = a.value.length,
                h = 0; h < u && ("0" == a.value.charAt(h) || a.value.charAt(h) == r) ; h++)
                    ;
                for (l = ""; h < u; h++)
                    -1 != "0123456789".indexOf(a.value.charAt(h)) && (l += a.value.charAt(h));
                if (l += n,
                0 == (u = l.length) && (a.value = ""),
                1 == u && (a.value = "0" + r + "0" + l),
                2 == u && (a.value = "0" + r + l),
                u > 2) {
                    for (ajd2 = "",
                    j = 0,
                    h = u - 3; h >= 0; h--)
                        3 == j && (ajd2 += e,
                        j = 0),
                        ajd2 += l.charAt(h),
                        j++;
                    for (a.value = "",
                    tamanho2 = ajd2.length,
                    h = tamanho2 - 1; h >= 0; h--)
                        a.value += ajd2.charAt(h);
                    a.value += r + l.substr(u - 2, u)
                }
                return !1
            }


        </script>
</asp:Content>
