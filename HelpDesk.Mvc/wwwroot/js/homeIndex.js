$(document).ready(function () {

    $("#btnLogin").click(function () {
        //   alert('Ekle Butonuna Basıldı');

        const form = $('#form-ticket-add');
        const dataToSend = form.serialize();
        /*  alert(dataToSend);*/
        $.post('/Home/Index/', dataToSend).done(function (data) {
            var url = "/Employee/Ticket";
            window.location = url;
        });
    });



});
