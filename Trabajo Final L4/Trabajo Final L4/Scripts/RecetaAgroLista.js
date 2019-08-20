var productos = [];

$(document).ready(function () {
    $('#tableRecetasAgro').DataTable();
    var tProductos = $('#tableRecetasAgroProductos').DataTable();
    $('#tableRecetasAgroProductos_wrapper').hide();
    
    $("#guardarProducto").click(function () {
        var idAgroquimico = $("#selectD").val();
        var valorAgroquimico = $("#selectD option:selected").text();;
        var cantidad = $("#selectCant").val();

        var producto = { idProducto: idAgroquimico, marcaComercial: valorAgroquimico, cantidad: cantidad };

        productos.push(producto);
        
        $('#exampleModalCenter').modal('hide');

        if (productos.length != 0) {
            $('#tableRecetasAgroProductos_wrapper').show();
            tProductos.row.add([producto.marcaComercial, producto.cantidad, '<button type="button" class="btn btn-outline-danger btn-Delete text-right">Eliminar</button>']).draw();
        }

    });

    //Eliminar de la tabla productos
    $('body').on('click', '.btn-Delete', function () {
        console.log('asasa');

        for (var i = 0; i < productos.length; i++) {
            console.log('Productos: ', productos.length);
            console.log('Producto seleccionado: ', productos[i]);
        }
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

//function creaProducto() {
//    var idAgroquimico = $("#selectD").val();
//    var valorAgroquimico = $("#selectD option:selected").text();;
//    var cantidad = $("#selectCant").val();
    
//    tProductos.row.add({
//        "idAgroquimico": idAgroquimico,
//        "marcaComercial": valorAgroquimico,
//        "cantidad": cantidad,
//    }).draw();
//}