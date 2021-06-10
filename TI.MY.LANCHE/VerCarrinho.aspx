<%@ Page Title="Meu Carrinho" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VerCarrinho.aspx.cs" Inherits="TI.MY.LANCHE.VerCarrinho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        window.addEventListener("load", function (event) {
            verPagina();
            gerarNumPedido();
        });

        $('#meuModal').on('shown.bs.modal', function () {
            $('#meuInput').trigger('focus')
        })
    </script>

    <style>
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

        .classtotal {
            color: #d34000 !important;
            font-style: italic;
            font-weight: bold;
            font-size: 30px;
            font-family: arial, sans-serif;
        }

        .h2, h2 {
            font-size: 2rem;
            color: #d34000;
        }

        .produtosIntTitulo {
            visibility: hidden;
            margin-top: -49px;
        }

        .modal-header {
            display: -ms-flexbox;
            display: flex;
            -ms-flex-align: start;
            align-items: flex-start;
            -ms-flex-pack: justify;
            justify-content: space-between;
            padding: 1rem 1rem;
            border-bottom: -64px solid #dee2e6;
            border-top-left-radius: calc(.3rem - 1px);
            border-top-right-radius: calc(.3rem - 1px);
        }

        .modal-title {
            color: black;
        }

        .valorTotal {
            color: black;
        }


        element.style {
        }

        .modal-body {
            position: relative;
            -ms-flex: 1 1 auto;
            flex: 1 1 auto;
            padding: 1rem;
            margin-top: -23px;
        }

        .Campos {
            margin-top: 0px;
            margin-bottom: 0rem;
            color: red;
        }

        .strongsobs {
            font-size: 20px;
        }
    </style>

    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

    <div class="container">
        <h2>Meu Carrinho</h2>

        <div class="col-md-12">

            <div id="itens"></div>
            <div class="classtotal"><strong>Total: <span id="total"></span></strong></div>

            <script>

                var total = 0; // variável que retorna o total dos produtos que estão na LocalStorage.
                var i = 0;     // variável que irá percorrer as posições
                var valor = 0; // variável que irá receber o preço do produto convertido em Float.

                for (i = 1; i <= 99; i++) // verifica até 99 produtos registrados na localStorage
                {
                    var prod = localStorage.getItem("produto" + i + ""); // verifica se há recheio nesta posição. 
                    var qt = localStorage.getItem("valor" + i);

                    if (prod != null) {

                        // exibe os dados da lista dentro da div itens
                        document.getElementById("itens").innerHTML += localStorage.getItem("quantidade" + i) + " x - ";
                        document.getElementById("itens").innerHTML += localStorage.getItem("produto" + i);
                        document.getElementById("itens").innerHTML += " ";

                        var obs = localStorage.getItem("Obs" + i);

                        if (obs === "") {
                            document.getElementById("itens").innerHTML += "R$: " + Number(localStorage.getItem("valor" + i)).toFixed(2).replace(".", ",") + "<hr>";
                        } else {
                            document.getElementById("itens").innerHTML += "R$: " + Number(localStorage.getItem("valor" + i)).toFixed(2).replace(".", ",") + "<strong class='strongsobs'> - OBS: " + localStorage.getItem("Obs" + i) + "</strong><hr>";
                        }

                        localStorage.setItem("listaDados", document.getElementById("itens").innerHTML += " ");

                        // calcula o total dos recheios
                        valor = parseFloat(localStorage.getItem("valor" + i)); // valor convertido com o parseFloat()
                        total = (total + valor); // arredonda para 2 casas decimais com o .toFixed(2)
                    }
                }
                // exibe o total dos recheios

                document.getElementById("total").innerHTML = total.toFixed(2);

                function moeda(a, e, r, t) {
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

            <button type="button" onclick="localStorage.clear(); location.reload();" class="btn btn-danger">Limpar carrinho</button>
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalExemplo" onclick="limparCampos()">Fechar Venda</button>

            <div id="numPedido" class="numPedido">Pedido Nº:</div>

        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="modalExemplo" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">PAGAMENTO</h5>

                    <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <div class="form-group">

                        <label for="tipoos" class="col-md-12 control-label">Selecione forma de Pagamento</label>
                        <div class="col-md-12">
                            <select class="form-control" id="cidades" name="cidadesname" data-placeholder="* Selecione Tipo de Pagamento" onmouseout="formaPagamento()">
                                <option value=""></option>
                                <option value="Dinheiro">1-Dinheiro</option>
                                <option value="Crédito">2-Crédito</option>
                                <option value="Débito">3-Débito</option>
                                <%--     <option value="4">4-PIX</option>--%>
                            </select>
                        </div>

                        <label for="tipoos" class="col-md-12 control-label">* Selecione forma de Retirada</label>
                        <div class="col-md-12">
                            <select class="form-control" id="retirada" name="retirada" data-placeholder="Selecione a cidade" onmouseout="formaEntrega()">
                                <option value=""></option>
                                <option value="Balcão">1-Balcão</option>
                                <option value="Delivery">2-Delivery</option>
                            </select>
                        </div>

                        <label for="tipoos" class="col-md-12  control-label">Informe R$ Valor em Troco</label>
                        <div class="col-md-12">
                            <input class="form-control" id="valor" type="text" name="valor" placeholder="0,00" onkeypress="return(moeda(this,'.',',',event))" />
                        </div>

                        <div class="col-md-12">
                            <form id="form2">
                                <div class="form-group">
                                    <label for="email">* Informe Endereço de Entrega:</label>
                                    <input type="text" class="form-control" id="endereco" placeholder="Ex. Avenida 7 de setembro, 123" />
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Informe uma Referencia:</label>
                                    <input type="text" class="form-control" id="referencia" placeholder="Ao lado posto combustivel" />
                                </div>
                                <p class="Campos">*Campos Obrigatório</p>
                            </form>
                        </div>

                        <h5 class="valorTotal">
                            <strong>R$ Valor Total :<span id="somatotal"></span></strong>
                        </h5>

                    </div>
                </div>
                <div class="modal-footer">

                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Sair</button>
                    <%--        <a class="btn btn-primary" href="https://api.whatsapp.com/send?phone=5516%996080056&text=*Pedido%20rhEBeYDin*%20-%20*Best%20Burgers*%0A---------------------------%0A%0A*4x%20Coca-cola%201%2C5L%20R%24%2020%2C00*%20_c%C3%B3d.%2045XV_%20%0A*1x%20Mega%20Burguer*%20_c%C3%B3d.%205RYK_%20%0A%20%E2%80%A2%20Frances%20%0A%0A*Subtotal%3A*%20R%24%2020%2C00%0A*Taxa%20de%20entrega%3A*%20Gr%C3%A1tis%0A*Taxa%20de%20embalagem%3A*%20Gr%C3%A1tis%0A%0A*Total%3A*%20R%24%2020%2C00%0A%0A---------------------------%0A*Retirada%20no%20local*%0A%0A*Pagamento%3A*%20Dinheiro%0A%0AAcompanhe%20seu%20pedido%20em%3A%0Aapp.qrmenus.com.br%2Fdemo-burguer%2Forder%2FrhEBeYDin," target="_blank" onclick="fecharPedido()">fechar</a>
                    --%>
                    <a class="btn btn-primary" id="mensagem-sucesso" onclick="pagamentos()">Confirmar Pedido</a>
                </div>
            </div>
        </div>
    </div>

    <script>

        function pagamentos() {

            var fp = window.document.getElementById("cidades");
            var fr = window.document.getElementById("retirada");
            var enderecoEntrega = window.document.getElementById("endereco");

            if (fr.value == "Balcão") {
                if (fp.value == "") {
                    alert("Informe uma Forma de Pagamento");
                } else if (fr.value == "") {
                    alert("Informe uma Forma de Retirada");
                } else {
                    pagamentoBalcao();
                }
            } else {
                if (fp.value == "") {
                    alert("Informe uma Forma de Pagamento");
                } else if (fr.value == "") {
                    alert("Informe uma Forma de Retirada");
                } else if (enderecoEntrega.value == '') {
                    alert("Informe uma Endereço de Entrega com Numero");
                } else {
                    pagamentoBalcao();
                }
            }
        };

        function pagamentoBalcao() {
            const playButton = document.getElementById('mensagem-sucesso');
            playButton.innerHTML = 'Fechar Pedido'
            playButton.style.backgroundColor = "#d34000";

            var fp = window.document.getElementById("cidades");
            var fr = window.document.getElementById("retirada");

            var nome = window.document.getElementById("nome");
            var celular = window.document.getElementById("celular");
            var lista = localStorage.getItem('listaDados');
            var tipopagamento = window.document.getElementById("cidades").value;
            var tiporetirada = window.document.getElementById("retirada").value;

            const nomeEmpresaZ = localStorage.getItem("nomeEmpresaWatts").toString().trim().replace(" ", "%20");

            var pedido = "Pedido Nº : " + numeroPedido.replace(" ", "%20");
            var celularCliente = $(".produtosIntTitulo").text();

            for (var i = 30; i >= 0; i--) {
                var novalista = lista.replace('<hr>', '%0A');
                lista.replace('<strong>', '*');
                lista.replace('</strong>', '*');
                lista.replace(' ', "%20");
            }

            const subtotal = total.toFixed(2).replace(".", "%2C");

            let texto = "";

            var enderecoEntrega = window.document.getElementById("endereco");
            var referencia = window.document.getElementById("referencia");
            var troco = window.document.getElementById("valor");

            if (enderecoEntrega.value == "") {
                texto = ("https://api.whatsapp.com/send?phone=55" + celularCliente + "&text=*" + pedido + "*%20%20%0A%0A%0A" + nomeEmpresaZ + "%20AGRADECE%20SUA%20PREFERENCIA%0A%0A*---------------------------*%0A%0A" + novalista + "%0A%0A%0A*Subtotal%3A*%20R%24%20" + subtotal + "%0A*Taxa%20de%20entrega%3A*%20Gr%C3%A1tis%0A*Taxa%20de%20embalagem%3A*%20Gr%C3%A1tis%0A%0A*Total:*%20R%24%20" + subtotal + "%0A%0A---------------------------%0A*Tipo%20Retirada:*%20" + tiporetirada + "%0A%0A*Pagamento%3A*%20" + tipopagamento + "%0A%0A%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20SEU%20PEDIDO%20FOI%20REALIZADO%20COM%20SUCESSO%20%20%0A%0A%0A%0A*Tempo%20Estimado%20de%2030%20à%2055%20Minutos.*%0A%0AAcompanhe%20seu%20App%20%20em%3A%0Aapp%20:%20http://idisque.com.br/" + nomeEmpresaZ.toString().toLowerCase().replace("%20", "-") + ".aspx").replace("<hr>", "%0A%0A").replace("<strong>", "*");
            } else {
                if (referencia.value == "") {
                    referencia.value = "*xxx*";
                }
                if (troco.value == "") {
                    troco.value = "%20R%24%200.00";
                }

                var textoendereco = "%0A%0A*ENDEREÇO%20ENTREGA:*%20%20" + enderecoEntrega.value + "%20.%0A*REFERENCIA:*%20" + referencia.value + "%0A*TROCO%20PARA:*%20" + troco.value;

                texto = ("https://api.whatsapp.com/send?phone=55" + celularCliente + "&text=*" + pedido + "*%20%20%0A%0A%0A" + nomeEmpresaZ + "%20AGRADECE%20SUA%20PREFERENCIA%0A%0A*---------------------------*%0A%0A" + novalista + "%0A%0A%0A*Subtotal%3A*%20R%24%20" + subtotal + "%0A*Taxa%20de%20entrega%3A*%20Gr%C3%A1tis%0A*Taxa%20de%20embalagem%3A*%20Gr%C3%A1tis%0A%0A*Total:*%20R%24%20" + subtotal + "%0A%0A---------------------------%0A*Tipo%20Retirada:*%20" + tiporetirada + textoendereco + "%0A%0A*Pagamento%3A*%20" + tipopagamento + "%0A%0A%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20SEU%20PEDIDO%20FOI%20REALIZADO%20COM%20SUCESSO%20%20%0A%0A%0A%0A*Tempo%20Estimado%20de%2030%20à%2055%20Minutos.*%0A%0AAcompanhe%20seu%20App%20%20em%3A%0Aapp%20:%20http://idisque.com.br/" + nomeEmpresaZ.toString().toLowerCase().replace("%20", "-") + ".aspx").replace("<hr>", "%0A%0A").replace("<strong>", "*");
            }

            var test = document.getElementById('mensagem-sucesso').onclick = function () {
                let a = document.createElement('a');
                a.target = '_blank'
                a.href = texto
                a.click() // simular o evento de "click"

                swal('Pedido Realizado com Sucesso!', 'Seu Pedido estara Pronto em 40 Minutos!', 'success')

                for (var i = 0; i < 1000; i++) {

                    limparCampos();

                    localStorage.clear();

                    location.reload();

                    window.history.back();
                }
            }
        };

        function pausecomp(millis) {
            var date = new Date();
            var curDate = null;
            do { curDate = new Date(); }
            while (curDate - date < millis);
        }

        function texto() {
            return "";
        }

        function formaPagamento() {
            var tipo = window.document.getElementById("cidades").value;

            if (tipo == "1") {
                document.getElementById("valor").disabled = false;
            } else if (tipo == 2)
                document.getElementById("valor").disabled = true;
            else if (tipo == 3)
                document.getElementById("valor").disabled = true;
            else if (tipo == 4)
                document.getElementById("valor").disabled = true;
        }

        function formaEntrega() {
            var tipoEntrega = window.document.getElementById("retirada").value;

            if (tipoEntrega == 'Delivery') {
                document.getElementById("endereco").disabled = false;
                document.getElementById("referencia").disabled = false;
                document.getElementById("valor").disabled = false;

                document.getElementById("endereco").focus();
            } else {
                document.getElementById("endereco").disabled = true;
                document.getElementById("referencia").disabled = true;
                document.getElementById("valor").disabled = true;
            }
        };

        function limparCampos() {
            document.getElementById("valor").value = '';
            document.getElementById("valor").disabled = true;
            document.getElementById("endereco").disabled = true;
            document.getElementById("referencia").disabled = true;

            document.getElementById("retirada").value = 0;
            document.getElementById("cidades").value = 0;

            somatotal = (total); // arredonda para 2 casas decimais com o .toFixed(2)

            document.getElementById("somatotal").innerHTML = somatotal.toFixed(2);
        };

        function fecharPedido() {
            alert('fechar');
            var fp = window.document.getElementById("cidades");
            var fr = window.document.getElementById("retirada");

            if (fp.value == "0") {
                alert("Informe uma Forma de Pagamento");
            } else if (fr.value == "0") {
                alert("Informe uma Forma de Retirada");
            }
            else {

                document.getElementById('mensagem-sucesso').onclick = function () {
                    swal('Pedido com Sucesso!', 'Seu Pedido foi Realizado com Sucesso!', 'success')
                };

                limparCampos();

                localStorage.clear();
                location.reload();

                var navegador = window.document.getElementById('navbar-nav').value;
            }
        };

        function delayer() {
            window.location = getQueryVariable('url')
        }


        function verPagina() {
            window.document.getElementById("nomeEmpresa").innerHTML = localStorage.getItem("nomeEmpresaWatts").toString().trim();
            if (Number(window.document.getElementById('total').innerHTML) == 0) {
                window.history.back();
            }
        }

        var numeroPedido = 0;
        function gerarNumPedido() {
            var data = new Date();
            var dia = String(data.getDate()).padStart(2, '0');
            var mes = String(data.getMonth() + 1).padStart(2, '0');
            var ano = data.getUTCFullYear();
            var hora = String(data.getHours()).padStart(2, '0');
            var min = String(data.getMinutes()).padStart(2, '0');
            var seg = String(data.getSeconds()).padStart(2, '0');

            numeroPedido = ("P" + ano + mes + dia + hora + min + seg);

            window.document.getElementById('numPedido').innerHTML = ("Nº Pedido: " + numeroPedido);
        };

    </script>
</asp:Content>
