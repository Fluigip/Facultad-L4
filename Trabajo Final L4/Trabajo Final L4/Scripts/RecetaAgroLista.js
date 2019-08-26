$(document).ready(function () {
    $('#tableRecetasAgro').DataTable();

    $('.btnDelete').click(function () {
        var id = $(this).attr('data-id');
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
