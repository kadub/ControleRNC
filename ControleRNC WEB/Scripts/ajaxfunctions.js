$(".desenho")
    .select2({
        ajax: {
            url: '/Produto/SearchProduct',
            dataType: 'json',
            type: 'GET',
            delay: 200,
            minimumInputLength: 3,
            data: function(params) {
                return {
                    filter: params.term // search term
                };
            },
            processResults: function(data) {
                return {
                    results: $.map(data,
                        function(item) {
                            return {
                                text: item.CodigoDescricao,
                                id: item.Codigo
                            }
                        })
                }
            }
        }
    });

$(".cliente")
    .select2({
        ajax: {
            url: '/Cliente/SearchClient',
            dataType: "json",
            type: 'GET',
            delay: 200,
            minimumInputLength: 3,
            data: function (params) {
                return {
                    filter: params.term // search term
                };
            },
            processResults: function (data) {
                return {
                    results: $.map(data,
                        function (item) {
                            return {
                                text: item.Nome,
                                id: item.Codigo
                            }
                        })
                }
            }
        }
    });

$("#CodigoCliente")
    .on("change",
        function() {
            var procura = $("#CodigoCliente").val();
            insertDataClient(procura);
        });

function insertDataClient(procura) {
    $.ajax({
        url: '/Cliente/SearchById',
        dataType: "json",
        type: 'GET',
        data: {
            codigo: procura
        },
        success: function (data) {
            $('#endereco').val(data.Endereco);
            $('#telefone').val(data.Telefone);
        },
        error:function() {
            alert("erro");
        }
    });
}

