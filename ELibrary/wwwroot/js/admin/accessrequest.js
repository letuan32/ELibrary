


//table=$(document).ready(function () {
//    $('#tblData').DataTable({
//        "scrollY": "450px",
//        "scrollCollapse": true,
//        "paging": true
//    });
/*});*/


function ChangeStatus(id) {

    $.ajax({
        type: "POST",
        url: '/Admin/AccessRequest/ChangeStatus/',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);   
                location.reload(true);
               /* $("#tblData").load("/Admin/AccessRequest/Index");*/
               
            }
            else {
                toastr.error(data.message);
            }
        }
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
                        location.reload(true);
                        
                        
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}