$(document).ready(function () {

    var ticketListUrl = "/Employee/Ticket/TicketList";



    $("#btnSaveTicket").click(function () {
        //   alert('Ekle Butonuna Basıldı');
        const form = $('#form-ticket-add');
        const dataToSend = form.serialize();

        $.post('/Employee/Ticket/Add/', dataToSend)
            .done(function (data) {
                if (data.success === true) {
                    /*  alert(data.success);*/
                    window.toastr.success(data.message, 'Success Alert', { timeout: 1800 });
                    setTimeout(methodFinish, 2000);

                }
            });
    });

    function methodFinish() {
        window.location = ticketListUrl;
    }

});

