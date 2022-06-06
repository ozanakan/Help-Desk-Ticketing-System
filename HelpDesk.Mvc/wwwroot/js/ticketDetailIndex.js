$(document).ready(function () {
   
    var ticketId = getParameterByName('ticketid');

    $("#btnSave").click(function () {


        var answer = $(".answer").val();
        var ticketAnswer = { TicketId: ticketId, Answer: answer };
        $.ajax({

            type: 'POST',
            url: '/Employee/Ticket/AnswerAdd/',
            data: { ticketAnswer }
        });
        setTimeout(methodFinish, 200);
    });

    function methodFinish() {
        document.location.reload(true);
    }


});