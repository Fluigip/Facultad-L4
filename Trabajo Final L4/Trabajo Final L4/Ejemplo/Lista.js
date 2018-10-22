$(document).ready(function () {
    $('#table').DataTable();   

    $('.btnDelete').click(function () {
        let row = $(this).closest('tr');
        let id = $(row).attr('data-id');

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: 'Lista.aspx/Eliminar',
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