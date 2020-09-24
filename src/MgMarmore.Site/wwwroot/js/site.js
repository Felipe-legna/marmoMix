
var urlAtual = window.location.href;

$(document).ready(function () {

    $("#cep").blur(function () {

        //Nova variável "cep" somente com dígitos.
        var cep = $(this).val().replace(/\D/g, '');

        //Verifica se campo cep possui valor informado.
        if (cep !== "") {

            //Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            //Valida o formato do CEP.
            if (validacep.test(cep)) {

                //Preenche os campos com "..." enquanto consulta webservice.
                $("#Endereco_Logradouro").val("...");
                $("#Endereco_Bairro").val("...");
                $("#Endereco_Cidade").val("...");
                $("#Endereco_Estado").val("...");

                //Consulta o webservice viacep.com.br/
                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?",
                    function (dados) {

                        if (!("erro" in dados)) {
                            //Atualiza os campos com os valores da consulta.
                            $("#Endereco_Logradouro").val(dados.logradouro);
                            $("#Endereco_Bairro").val(dados.bairro);
                            $("#Endereco_Cidade").val(dados.localidade);
                            $("#Endereco_Estado").val(dados.uf);
                        } //end if.
                        else {
                            //CEP pesquisado não foi encontrado.
                            limpa_formulário_cep();
                            alert("CEP não encontrado.");
                        }
                    });
            } //end if.
            else {
                //cep é inválido.
                limpa_formulário_cep();
                alert("Formato de CEP inválido.");
            }
        } //end if.
        else {
            //cep sem valor, limpa formulário.
            limpa_formulário_cep();
        }
    });

    

    $("#atualizarEndereco").click(function () {       

        var formulario = $("#dadosEndereco");
        var obj = getFormData(formulario);
        $.ajax({            
            url: "/atualizar-endereco-cliente/" + obj['Endereco.ClienteId'],
            type:"POST",
            //dataType: "json",
            data: obj,
            success: function (data) {
                $('#EnderecoTarget').load(data.url);
               
                //$("#exampleModalLong").modal('hide');
            },
            error: function (xhr, err) {
                alert("readyState: " + xhr.readyState + "\nstatus: " + xhr.status);
                alert("responseText: " + xhr.responseText);
            }
        });

    });


    $("#adicionar").click(function () {
        var pecas = [];
        for (var i = 0; i < 1; i++) {
            var id = i + 1;
            var largura = $("#largura-" + id).val();
            var comprimento = $("#comprimento-" + id).val();
            pecas.push({ "LarguraPeca": largura, "ComprimentoPeca": comprimento });
        }

        var frontao = $("#frontao").val();
        var saia = $("#saia").val();
        var idBancada = $("#idBancada").val();

        var bancada = {
            "Frontao": frontao,
            "Saia": saia,
            "Pecas": pecas
        };

        $.ajax({
            url: "/adicionar-bancada/" + idBancada,
            type: "POST",
            dataType: "json",
            contentType: 'application/x-www-form-urlencoded; charset=utf-8',
            data: bancada,
            success: function (data) {
                alert("Adicionado com sucesso");

            },
            error: function (xhr, err) {
                alert("readyState: " + xhr.readyState + "\nstatus: " + xhr.status);
                alert("responseText: " + xhr.responseText);
            }
        });

    });
    
});


function AtualizaEndereco() {

}

function limpa_formulário_cep() {
    // Limpa valores do formulário de cep.
    $("#Endereco_Logradouro").val("");
    $("#Endereco_Bairro").val("");
    $("#Endereco_Cidade").val("");
    $("#Endereco_Estado").val("");
}


function getFormData($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}

function AdicionarBancada(quantidadePecas) {
    
    var pecas = [];
    for (var i = 0; i < quantidadePecas; i++) {
        var id = i+1;
        var largura = $("#largura-" + id).val();
        var comprimento = $("#comprimento-" + id).val();
        pecas.push({ "LarguraPeca": largura, "ComprimentoPeca": comprimento });
    }

    var frontao = $("#frontao").val();
    var saia = $("#saia").val();


    var data = {
        "Frontao": frontao,
        "Saia": saia,
        "Pecas": pecas
    };


    //$.ajax({
    //    url: '/Modelo/adicionar-modelo',
    //    type: 'GET',
    //    data: { 'categoriaId': id },
    //    success: function (response) {
    //        for (var i = 0; i < response.length; i++) {
    //            $("#material").append("<option id=" + response[i].Id + " value=" + response[i].Valor + ">" + response[i].Nome + "</option>");
    //        }
    //        $("#valorMaterial").val(formataTela(response[0].Valor));
    //    },
    //    error: function (error) {
    //        $(this).remove();
    //    }
    //});


    $.ajax({
        type: "POST",
        url: "/modelo/adicionar-modelo",
        data: data,
        contentType: "application/json; charset=utf-8",
        //dataType: "json",
        success: function (msg) {
            // Replace the div's content with the page method's return.
            $("#Result").text(msg.d);
        }
    });
    
}


