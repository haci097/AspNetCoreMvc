$(document).ready(function () {
    $('#tblProduct').dataTable({
        "language": {
            "paginate": {
                "previous": "<",
                "next": ">",
            },
            "sSearch": "Axtar:",
            "info": "Ümumi qeydiyyat sayı: _TOTAL_",
            "infoEmpty": "Ümumi qeydiyyat sayı: _TOTAL_",
            "infoFiltered": "",
            "emptyTable": "Data mövcud deyil"
        },
        "lengthChange": false,

    });
});

$(document).ready(function () {
    $('#tblCategory').dataTable({
        "language": {
            "paginate": {
                "previous": "<",
                "next": ">",
            },
            "sSearch": "Axtar:",
            "info": "Ümumi qeydiyyat sayı: _TOTAL_",
            "infoEmpty": "Ümumi qeydiyyat sayı: _TOTAL_",
            "infoFiltered": "",
            "emptyTable": "Data mövcud deyil"
        },
        "lengthChange": false,

    });
});