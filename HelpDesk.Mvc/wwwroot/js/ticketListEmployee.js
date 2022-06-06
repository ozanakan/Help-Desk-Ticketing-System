$(document).ready(function () {


    $(".btn-Detail").click(function () {

        var ticketId = $(this).attr('ticket-id');
        var ticketDetail = { TicketId: ticketId };
        $.ajax({
            type: 'POST',
            url: '/Employee/Ticket/TicketDetail/',
            data: { ticketDetail }
        });
        var tickedDetailUrl = '/Employee/Ticket/Detail?ticketid=' + ticketId;
        window.location = tickedDetailUrl;
    });





});