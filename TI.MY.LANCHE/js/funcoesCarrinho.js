
//FUNCCAO DE CONVERTER VALORES
function moedaParaFloat(_valor) {
    let textoLimpo = _valor.replace("R$", "").replace(",", ".")
    return parseFloat(textoLimpo);
}

function floatParaMoeda(_valor) {
    let valorFormatado = (_valor < 1 ? "0" : "") + Math.floor(_valor * 100);
    valorFormatado = "R$" + valorFormatado;
    return valorFormatado.substr(0, valorFormatado.length - 2) + "," + valorFormatado.substr(-2);
}

function retornoTotal() {
    let valortotal = document.querySelector("#total");
    return moedaParaFloat(valortotal.innerHTML);
}

function escreverTotal(_valor) {
    let valortotalEsc = document.querySelector("#total");
    valortotalEsc.innerHTML = floatParaMoeda(_valor);
}

function calcularTotaProdutos() {
  
    let todoProdutos = document.querySelectorAll('.preco-produto');
    let todaQuantidade = document.querySelectorAll('.quantidade');

    let totaProduto = 0;

    for (let i = 0; i < todoProdutos.length; i++) {
        let umPreoc = moedaParaFloat(todoProdutos[i].innerHTML);
        let umaQtde = moedaParaFloat(todaQuantidade[i].value);
        let subtotal = umPreoc * umaQtde;

        totaProduto += subtotal;
    }

    return totaProduto;
}

function qtdeMudou() {
   
    escreverTotal(calcularTotaProdutos());
}

function aoCarregarPagina() {
    let quantidade = document.querySelectorAll('.quantidade');

    for (let x = 0; x < quantidade.length; x++)
    {
        quantidade[x].onchange = (function ()
        {
            qtdeMudou();
        });
    }
}

window.onload = (function ()
{
    aoCarregarPagina()
    qtdeMudou()
});