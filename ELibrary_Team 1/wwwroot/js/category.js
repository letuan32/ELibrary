var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Authenticated/Category/GetAll"
        },
        "columns": [
            { "data": "title", "width": "60%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
    <a href="/Authenticated/Category/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
        <i class="fas fa-edit"></i>
    </a>
    <a onclick=Delete("/Authenticated/Category/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
        <i class="fas fa-trash-alt"></i>
    </a>
</div>
                           `;
                }, "width": "40%"
            }
        ]
    });
}