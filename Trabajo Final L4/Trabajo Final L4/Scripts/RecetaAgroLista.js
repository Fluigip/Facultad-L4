var productos = [];

$(document).ready(function () {
    $('#tableRecetasAgro').DataTable();
    $('#tableRecetasAgroProductos').hide();
    $('#tituloRecetaProductos').hide();
    
    $("#guardarProducto").click(function () {
        var idAgroquimico = $("#selectD").val();
        var valorAgroquimico = $("#selectD option:selected").text();;
        var cantidad = $("#selectCant").val();

        var producto = { idProducto: idAgroquimico, marcaComercial: valorAgroquimico, cantidad: cantidad };

        productos.push(producto);
        
        $('#exampleModalCenter').modal('hide');

        if (productos.length != 0) {
            $('#tituloRecetaProductos').show();
            $('#tableRecetasAgroProductos').show();
            var fila = '<tr><td>' + producto.marcaComercial + '</td><td>' + producto.cantidad + '</td><td> <button type="button" class="btn btn-outline-danger btn-Delete text-right">Eliminar</button></td></tr>';
            $("#tableRecetasAgroProductos tbody").append(fila);
        }

    });

    $('body').on('click', '.btn-Delete', function () {
        var aEliminar = $(this).closest("tr");
        var filas = $('#tableRecetasAgroProductos tbody tr');
        var i = filas.index(aEliminar);

        productos.splice(i, 1);
        $(this).closest("tr").remove();
    });

    $('.btnDelete').click(function () {
        let id = $(this).attr('data-id');
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: 'RecetasAgroquimicas.aspx/Eliminar',
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
