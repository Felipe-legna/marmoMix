
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