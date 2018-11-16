$(document).ready(function () {
    $('#tableSolicitud').DataTable();

    $('.btnDelete').click(function () {
        let id = $(this).attr('data-id');
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: 'Solicitudes.aspx/Eliminar',
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