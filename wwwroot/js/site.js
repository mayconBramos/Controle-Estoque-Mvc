// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const { type } = require("jquery");

// Write your JavaScript code.

$('.container').click(function () {
    $('.alert').hide('hide');
})

var qntdRetirar = document.getElementById('qntdRetirar').value;
var qntdEstoque = document.getElementById('qntdEstoque').value;

function Sobra() {
    if (qntdRetirar < qntdEstoque) {
        
    }
    else if (qntdRetirar > qntdEstoque) {
        alert = "Quantidade maior que a do estoque"
        return false;
    }
    else {
        return true;
    }
}