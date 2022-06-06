$(document).ready(function () {

    function methodFinish() {
        document.location.reload(true);
    }

    $(".btn-Detail").click(function () {

        var ticketId = $(this).attr('ticket-id');
        var ticketDetail = { TicketId: ticketId };
        $.ajax({
            type: 'POST',
            url: '/Employee/Ticket/TicketDetail/',
            data: { ticketDetail }
        });

        var tickedDetailUrl = '/Admin/Ticket/Detail?ticketid=' + ticketId;
        window.location = tickedDetailUrl;
    });


    $(".btn-Status").click(function () {

        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                var ticketId = $(this).attr('ticket-id');
                var ticketUpdateDto = { Id: ticketId };
                $.ajax({
                    async: true,
                    type: 'POST',
                    url: '/Employee/Ticket/StatusUpdate/',
                    data: { ticketUpdateDto }
                }).done(function (data) {
                    if (data.success === true) {
                         /* alert(data.success);*/
                        window.toastr.success(data.message, 'Success Alert', { timeout: 1800 });
                        setTimeout(methodFinish, 2000);
                    }
                });

            }
        });





    });
});