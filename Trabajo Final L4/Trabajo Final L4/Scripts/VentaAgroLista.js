$(document).ready(function () {
    $('#tablaVenta').DataTable();
    $('.agroquimico-detalle').hide();

    $('.agregar-Producto').on('click', function () {
        $('.agroquimico-detalle').show();
    });

    $('.crear-Producto').on('click', function () {
        debugger
        var agroquimico = $('#agroquimico').val();
        var cantidad = $('#cantidadProducto').val();
        var precio = $('#precioProducto').val();
        //agregar nuevo registro a la tabla (Consulta a la Base y armar tabla 
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: 'VentaAgroquimicaABM.aspx/BuscarAgroquimico',
            data: JSON.stringify({ id: agroquimico }),
            success: (function (data) {
                debugger
                var response = JSON.parse(data.d);




            }),
            error: (function () {
                alert("Error");
            })
        });

        $('.agroquimico-detalle').hide();
    });

    $('.btnDelete').click(function () {
        let id = $(this).attr('data-id');
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: 'VentaAgroquimico.aspx/Eliminar',
            data: JSON.stringify({ id: id }),
            success: (function (data) {
                alert(data.d);
                location.reload();
            }),
            error: (function () {
                alert("Error");
            })
        });
    });
});

