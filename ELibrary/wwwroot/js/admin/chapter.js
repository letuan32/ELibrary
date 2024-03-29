﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Chapter/GetAll/"
        },
        "columns": [
            { "data": "document.title", "width": "20%" },
            { "data": "number", "width": "5%" },
            { "data": "title", "width": "20%" },
            { "data": "content", "width": "50%" },
            { "data": "isUnlock", "width": "5%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Chapter/Upsert/${data}" class="btn btn-success text-white">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Delete("/Admin/Chapter/Delete/${data}") class="btn btn-danger text-white">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "40%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
