﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="degraus-nautico.aspx.cs" Inherits="TI.MY.LANCHE.degraus_nautico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="iFrameScript" runat="server" />

    <script>
        window.addEventListener("load", function (event) {
            var valorDaDiv = $(".produtosIntTitulo").text();
            $("#orcamentoAssuntoForm").val(valorDaDiv);

            var valornome = $(".nomeEmpresa").text();

            localStorage.setItem("nomeEmpresaWatts", valornome);
        });
    </script>

    <style>
        .strong {
            color: red;
        }

        dados {
            width: 100%;
            color: red;
        }

        .produtosIntTitulo {
            visibility: hidden;
            margin-top: -49px;
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

        strong {
            font-size: 21px;
            margin-right: inherit;
            color: #d34000;
        }

        .strong-preco {
            font-size: 30px;
            margin-right: inherit;
            color: red;
        }

        .card-title {
            color: black;
        }

        .modal-title {
            color: black;
        }

        .imagelogo {
            border-radius: 100%;
        }
    </style>

    <script>

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

                window.location.href = "degraus-nautico.aspx";
            }

            function IrCarrinho() {

                let nomeUsuario = localStorage.setItem("valor" + 0, valor);

                if (nomeUsuario.length > 0) {
                    window.location.href = "VerCarrinho.aspx";
                }
            };

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

    </div>
</asp:Content>
