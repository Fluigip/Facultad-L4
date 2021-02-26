$(document).ready(function () {
    $('#tablaVenta').DataTable();
    $('.agroquimico-detalle').hide();

    $('.agregar-Producto').on('click', function () {
        $('#idMovimiento').val(0);
        $('#agroquimico').val('');
        $('#cantidadProducto').val('');
        $('#precioProducto').val('');
        $('.agroquimico-detalle').show();
    });

    $('.crear-Producto').on('click', function () {
        var agroquimico = $('#agroquimico').val();
        var cantidad = $('#cantidadProducto').val();
        var precio = $('#precioProducto').val();
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: 'VentaAgroquimicaABM.aspx/BuscarAgroquimico',
            data: JSON.stringify({ id: agroquimico }),
            success: (function (data) {
                var response = JSON.parse(data.d);

                switch (response.resultado) {
                    case 1:
                        if ($('#idAgregarDetalle').val() == 0) {
                            var row = '<tr data-id="' + response.id + '"> ' +
                                '<td class="text-center">' + response.codigo + '</td>' +
                                '<td>' + response.marcaComercial + '</td>' +
                                '<td class="text-center">' + response.capacidadEnvase + '</td>' +
                                '<td class="text-center">' + response.unidadMedida + '</td>' +
                                '<td class="text-center">' + cantidad + '</td>' +
                                '<td class="text-center">' + precio + '</td>' +

                                '<td class="text-align-center" style="width: 80px; margin-left: 13px;">' +
                                ' <a role= "button" class="btn btn-warning text-white btn-sm custom-tooltip producto-editar" ' +
                                'title= "" data-original-title="Editar" > ' +
                                '<i class="fas fa-pencil-alt"></i> ' +
                                ' </a> ' +
                                '<button type= "button" class="btn btn-danger btn-sm custom-tooltip producto-eliminar" data-original-title="Eliminar"> ' +
                                '<i class="fas fa-trash" ></i> ' +
                                ' </button> ' +
                                '</td>' +
                                '</tr>';

                            $('#table-agroquimicos tbody').append(row);
                        } else {
                            var row = $('#table-agroquimicos tr[data-id="' + response.id + '"]');
                            row.find("td").eq(0).html(response.codigo);
                            row.find("td").eq(1).html(response.marcaComercial);
                            row.find("td").eq(2).html(response.capacidadEnvase);
                            row.find("td").eq(3).html(response.unidadMedida);
                            row.find("td").eq(4).html(cantidad);
                            row.find("td").eq(5).html(precio);
                        }

                        $('.agroquimico-detalle').hide();

                        break;
                    case 0:
                        popupAdvertencia(undefined, response.mensaje);
                        break;
                    default:
                        popupError(undefined, response.detallesError);
                        break;
                }
            }),
        });
    });

    $('body').on('click', '.producto-editar', function () {
        var idAgroquimico = $(this).closest("tr").attr('data-id');
        var cantidad = $(this).closest("tr").find("td").eq(4).html();
        var precio = $(this).closest("tr").find("td").eq(5).html();

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: 'VentaAgroquimicaABM.aspx/BuscarAgroquimico',
            data: JSON.stringify({ id: idAgroquimico }),
            success: (function (data) {
                var response = JSON.parse(data.d);

                switch (response.resultado) {
                    case 1:
                        $('#idAgregarDetalle').val(response.id);
                        $('#agroquimico').val(response.id);
                        $('#cantidadProducto').val(cantidad);
                        $('#precioProducto').val(precio);
                        $('.agroquimico-detalle').show();
                        break;
                    case 0:
                        popupAdvertencia(undefined, response.mensaje);
                        break;
                    default:
                        popupError(undefined, response.detallesError);
                        break;
                }
            })
        });
    });

    $('body').on('click', '.producto-eliminar', function () {
        var idProducto = $(this).closest("tr").attr('data-id');

        confirmModal("Eliminar Producto", "¿Esta seguro que desea eliminar este producto?", function () {
            var row = $('#table-agroquimicos tr[data-id="' + idProducto + '"]');
            $(row).remove();

        });
    });

    $('.guardarVenta').click(function () {
        debugger

        var venta =     {
            nombreCliente: $('#nombreCliente').val(),
            apellidoCliente: $('#apellidoCliente').val(),
            direccionCliente: $('#direccionCliente').val(),
            telefonoCliente: $('#telefonoCliente').val(),
            empresaCliente: $('#empresaCliente').val(),
            direccionEmpresa: $('#direccionEmpresa').val(),
            codigoPostalEmpresa: $('#codigoPostalEmpresa').val(),
            telefonoEmpresa: $('#telefonoEmpresa').val()
        }


    });

});

function confirmModal(titulo, mensaje, callback, cancelCallback, textoSi, textoNo) {
    if (typeof textoSi === 'undefined')
        textoSi = 'Aceptar';
    if (typeof textoNo === 'undefined')
        textoNo = 'Cancelar';

    var confirmModal = $('<div class="modal fade" id="popupConfirmacion" tabindex="-1" role="dialog" aria-hidden="true">' +
        '<div class="modal-dialog" role="document">' +
        '<div class="modal-content">' +
        '<div class="modal-header">' +
        '<h4 class="modal-title">' + titulo + '</h4>' +
        '</div>' +
        '<div class="modal-body">' +
        '<div class="fl">' + mensaje + '</div>' +
        '<div class="clear"></div>' +
        '</div>' +
        '<div class="modal-footer">' +
        '<button id="confirmBtn" type="button" class="btn btn-warning"><i class="fa fa-check"></i>&nbsp; ' + textoSi + '</button>' +
        '<button id="cancelBtn" type="button" data-dismiss="modal" class="btn btn-default" data-dismiss="modal"><i class="fa fa-times"></i>&nbsp; ' + textoNo + '</button>' +
        '</div>' +
        '</div>' +
        '</div>' +
        '</div>');

    confirmModal.find('#confirmBtn').click(function () {
        callback ? callback() : '';
        confirmModal.modal('hide');
    });
    confirmModal.find('#cancelBtn').click(function () {
        cancelCallback ? cancelCallback() : '';
        confirmModal.modal('hide');
    });

    //confirmModal.modal('show');
    confirmModal.modal({
        keyboard: false,
        backdrop: 'static'
    });
}

