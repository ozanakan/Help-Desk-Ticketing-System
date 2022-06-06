$(document).ready(function () {
    $('#companyTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>"
        //,
        //buttons: [
        //    {
        //        text: 'Ekle',
        //        attr: {
        //            id: "btnAdd"
        //        },
        //        className: 'btn btn-success',
        //        action: function (e, dt, node, config) {
        //            /*  alert('Ekle Butonuna Basıldı');*/
        //        }
        //    },
        //    {
        //        text: 'Yenile',
        //        className: 'btn btn-warning',
        //        action: function (e, dt, node, config) {

        //        }
        //    }
        //]
    });
    //$(function () {
    //    /*       const url = '@Url.Action("Add", "Area")';*/
    //    const url = '/Admin/Employee/Add/';
    //    const placeHolderDiv = $('#modelPlaceHolder');
    //    $('#btnAdd').click(function () {
    //        $.get(url).done(function (data) {
    //            placeHolderDiv.html(data);
    //            placeHolderDiv.find(".modal").modal('show');
    //        });
    //    });
    //});


    $("#btnSave").click(function () {

        var userName = $('#userName').val();
        var companyId = $("#companyName").val();
        var roleId = $('#roleName').val();
        var email = $('#email').val();
        var password = $('#password').val();
        var adminId = $("#admin").val();
        alert(userName + companyId + roleId + email + password + adminId);

        var userAddDto = { CompanyId: companyId, Name: userName, Email: email, Password: password, AdminId: adminId };

        $.ajax({
            /* async: true,*/
            type: 'POST',
            /* dataType: 'JSON',*/
            /*  contentType: 'application/json;charset=utf-8',*/

            url: '/Admin/Employee/Add/',
            /*  data: JSON.stringify(userAddDto)*/
            data: { userAddDto }
            //,

            //success: function (response) {
            //    if (response.success === true) {
            //        toastr.success(response.message, 'Success Alert', { timeout: 3000 });

            //    } else {
            //        toastr.error(response.message, 'Error Alert', { timeout: 3000 });
            //    }
            //},
            //error: function () {
            //    toastr.message('There is some problem to process your request.', 'Error Alert', { timeout: 3000 });
            //}
        });
        setTimeout(methodFinish, 200);
    });

    function methodFinish() {
        document.location.reload(true);
    }

});