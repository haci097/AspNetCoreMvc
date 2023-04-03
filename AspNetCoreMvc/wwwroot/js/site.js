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
            "emptyTable": "Data mövcud deyil",
            "zeroRecords": "Axtarışa uyğun qeydiyyat tapılmadı"
        },
        dom: 'Bfrtip',
        buttons: [
            'pdf',
            'excel',
            { extend: 'print', text: 'Çap Et' }
        ],
        "lengthChange": false
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
            "emptyTable": "Data mövcud deyil",
            "zeroRecords": "Axtarışa uyğun qeydiyyat tapılmadı"
        },
        dom: 'Bfrtip',
        buttons: [
            'pdf',
            'excel',
            { extend: 'print', text: 'Çap Et' }
        ],
        "lengthChange": false
    });
});