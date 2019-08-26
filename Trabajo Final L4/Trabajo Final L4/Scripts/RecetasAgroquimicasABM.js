$(document).ready(function () {

    $('#tableRecetasAgroProductos').hide();
    $('#tituloRecetaProductos').hide();

    if (productos.length !== 0) {
        $.each(productos, function (i, producto) {
            var fila = '<tr><td>' + producto.marcaComercial + '</td><td>' + producto.cantidad + '</td><td> <button type="button" class="btn btn-outline-danger btn-Delete text-right">Eliminar</button></td></tr>';
            $("#tableRecetasAgroProductos tbody").append(fila);
        });

        $('#tituloRecetaProductos').show();
        $('#tableRecetasAgroProductos').show();
    }

    $("#guardarProducto").click(function () {

        var idAgroquimico = $("#selectD").val();
        var valorAgroquimico = $("#selectD option:selected").text();
        var cantidad = $("#selectCant").val();
        var producto = { idProducto: idAgroquimico, marcaComercial: valorAgroquimico, cantidad: cantidad };

        productos.push(producto);

        $('#exampleModalCenter').modal('hide');

        if (productos.length !== 0) {
            $('#tituloRecetaProductos').show();
            $('#tableRecetasAgroProductos').show();
            var fila = '<tr><td>' + producto.marcaComercial + '</td><td>' + producto.cantidad + '</td><td> <button type="button" class="btn btn-outline-danger btn-Delete text-right">Eliminar</button></td></tr>';
            $("#tableRecetasAgroProductos tbody").append(fila);
            //Serializar row
            var nuevosProductos = JSON.stringify(productos);
            var inputProductos = document.getElementById('listaProductos');
            inputProductos.setAttribute('value', nuevosProductos);
        }
    });

    $('body').on('click', '.btn-Delete', function () {
        var aEliminar = $(this).closest("tr");
        var filas = $('#tableRecetasAgroProductos tbody tr');
        var i = filas.index(aEliminar);

        productos.splice(i, 1);
        $(this).closest("tr").remove();
        //Serializar row
        var eliminarProductos = JSON.stringify(productos);
        var inputProductos = document.getElementById('listaProductos');
        inputProductos.setAttribute('value', eliminarProductos);

    });
});