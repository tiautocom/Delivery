<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrinho.aspx.cs" Inherits="TI.MY.LANCHE.Carrinho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carrinho de Compra</title>
    <link href="css/resete.css" rel="stylesheet" />
    <link href="css/formatacao.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header>
                <h1 class="logo">Pastelaria Alameda</h1>
            </header>

            <main>
                <h2>Carrinho de Compras</h2>

                <table id="tabela-carrinho">
                    <thead>
                        <tr>
                            <th colspan="2"></th>
                            <th
                                class="coluna-pequena">Quantidade
                            </th>
                            <th>Preço
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <%--CORPO DO TR --%>

                        <tr>
                            <td class="coluna-capa">
                                <img src="img/nirvana-nevermind.jpeg" class="capa" />
                            </td>
                            <td>
                                <div class="produto">
                                    <a href="#" class="nome-artista">Music Detailse</a> -
                                    <a href="#" class="nome-produto">Nirvana</a>

                                </div>
                                <strong class="detalhe">Detalhes</strong>
                                <div>
                                    <label class="precisa-troco">
                                        <input type="checkbox" />Precisa de Troco
                                    </label>
                                </div>
                                <a href="#" class="remover-carrinho">Tirar do Carrinho</a>
                            </td>

                            <td>
                                <input type="number" value="1" max="5" min="0" class="quantidade" />
                            </td>
                            <td><span class="preco-produto">R$ 129,90</span></td>
                        </tr>

                        <tr>
                            <td class="coluna-capa">
                                <img src="img/big4live.jpeg" class="capa" />
                            </td>
                            <td>
                                <div class="produto">
                                    <a href="#" class="nome-artista">Cachorro Grande</a> -
                                    <a href="#" class="nome-produto">Cinema</a>

                                </div>
                                <strong class="detalhe">Detalhes</strong>
                                <div>
                                    <label class="precisa-troco">
                                        <input type="checkbox" />Precisa de Troco
                                    </label>
                                </div>
                                <a href="#" class="remover-carrinho">Tirar do Carrinho</a>
                            </td>

                            <td>
                                <input type="number" value="1" max="5" min="0" class="quantidade" />
                            </td>
                            <td><span class="preco-produto">R$ 114,00</span></td>
                        </tr>
                        <tr>
                            <td class="coluna-capa">
                                <img src="img/skol.jpg" class="capa" />
                            </td>
                            <td>
                                <div class="produto">
                                    <a href="#" class="nome-artista">Music Detailse</a> -
                                    <a href="#" class="nome-produto">Nirvana</a>

                                </div>
                                <strong class="detalhe">Detalhes</strong>
                                <div>
                                    <label class="precisa-troco">
                                        <input type="checkbox" />Precisa de Troco
                                    </label>
                                </div>
                                <a href="#" class="remover-carrinho">Tirar do Carrinho</a>
                            </td>

                            <td>
                                <input type="number" value="1" max="5" min="0" class="quantidade" />
                            </td>
                            <td><span class="preco-produto">R$ 68,90</span></td>
                        </tr>
                        <tr>
                            <td class="coluna-capa">
                                <img src="img/noticia_pastel.png" class="capa" />
                            </td>
                            <td>
                                <div class="produto">
                                    <a href="#" class="nome-artista">Music Detailse</a> -
                                    <a href="#" class="nome-produto">Nirvana</a>

                                </div>
                                <strong class="detalhe">Detalhes</strong>
                                <div>
                                    <label class="precisa-troco">
                                        <input type="checkbox" />Precisa de Troco
                                    </label>
                                </div>
                                <a href="#" class="remover-carrinho">Tirar do Carrinho</a>
                            </td>

                            <td>
                                <input type="number" value="1" max="5" min="0" class="quantidade" />
                            </td>
                            <td><span class="preco-produto">R$ 99,90</span></td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan="3" class="texto-total">Total da Compra</td>
                            <td><span id="total">R$ 0,00</span></td>
                        </tr>
                    </tfoot>
                </table>
            </main>
            <script src="js/funcoesCarrinho.js"></script>
        </div>
    </form>
</body>
</html>
