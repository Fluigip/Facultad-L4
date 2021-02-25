$(document).ready(function () {
    $('#tablaVenta').DataTable();

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

inicializarTooltips();

/*
* Inicialza los tooltips de Bootstrap
*/
function inicializarTooltips() {
    $('.custom-tooltip').tooltip(
        {
            container: 'body'
        });
}
