using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Entities.Concrete;
using HelpDesk.Entities.Dtos;
using HelpDesk.Mvc.Areas.Admin.Models;
using HelpDesk.Mvc.Areas.Employee.Models;
using HelpDesk.Services.Abstract;
using Microsoft.AspNetCore.Http;

namespace HelpDesk.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TicketController : Controller
    {

        private readonly ITicketService _ticketService;
        private readonly ITicketAnswerService _ticketAnswerService;

        public TicketController(ITicketService ticketService, ITicketAnswerService ticketAnswerService)
        {
            _ticketService = ticketService;
            _ticketAnswerService = ticketAnswerService;
        }





        public IActionResult NewTicket(TicketListViewModel ticketListViewModel)
        {

            var ticketList = _ticketService.GetAll();
            ticketListViewModel.TicketList = ticketList;


            return View(ticketListViewModel);
        }
        [HttpGet]
        public IActionResult Detail(TicketListModel ticketListModel)
        {
            try
            {
                var ticketIdSession = Convert.ToInt32(HttpContext.Session.GetString("TicketId"));
                var userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
                var ticketList = _ticketService.GetAll();
                //    var ticketAnswerList=_ticketAnswerService
                //   ticketListViewModel.TicketList = ticketList;

                var ticketListId = new List<TicketDetailDto>();
                foreach (var ticket in ticketList.Data.Tickets)
                {
                    if (ticket.TicketId == ticketIdSession)
                    {
                        var ticketId = new TicketDetailDto
                        {
                            UserId = userId,
                            UserName = ticket.UserName,
                            Title = ticket.Title,
                            StatusId = ticket.StatusId,
                            StatusName = ticket.StatusName,
                            Description = ticket.Description,
                            CreatedDate = ticket.CreatedDate,
                            FinalDate = DateTime.Now,
                            TicketId = ticket.TicketId,
                            AdminId = 2,
                            AdminName = "asd",
                            UserEmail = ticket.UserEmail
                        };
                        ticketListId.Add(ticketId);
                    }
                }
                ticketListModel.Tickets = ticketListId;



                var ticketAnswerList = _ticketAnswerService.GetAll();
                var ticketAnswerListId = new List<TicketAnswer>();
                foreach (var ticketAnswer in ticketAnswerList.Data.TicketAnswer)
                {
                    if (ticketAnswer.TicketId == ticketIdSession)
                    {
                        var ticketAnswerId = new TicketAnswer
                        {
                            Answer = ticketAnswer.Answer,
                            CreatedDate = DateTime.Now,
                            Ticket = ticketAnswer.Ticket,
                            Name = ticketAnswer.Name,
                            TicketId = ticketAnswer.TicketId,
                            Id = ticketAnswer.Id
                        };
                        ticketAnswerListId.Add(ticketAnswerId);
                    }
                }
                ticketListModel.TicketAnswers = ticketAnswerListId;


                return View(ticketListModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

    }
}
