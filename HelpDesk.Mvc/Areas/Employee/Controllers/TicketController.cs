using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HelpDesk.Data.Concrete.EntityFrameWork.Contexts;
using HelpDesk.Entities.Concrete;
using HelpDesk.Entities.Dtos;
using HelpDesk.Mvc.Areas.Admin.Models;
using HelpDesk.Mvc.Areas.Employee.Models;
using HelpDesk.Services.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HelpDesk.Mvc.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class TicketController : Controller
    {

        private readonly HelpDeskContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ITicketService _ticketService;
        private readonly ITicketAnswerService _ticketAnswerService;

        public TicketController(HelpDeskContext context, IWebHostEnvironment hostEnvironment, ITicketService ticketService, ITicketAnswerService ticketAnswerService)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _ticketService = ticketService;
            _ticketAnswerService = ticketAnswerService;
        }


        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        public IActionResult TicketDetail(TicketDetailDto ticketDetail)
        {
            try
            {
                HttpContext.Session.SetString("TicketId", ticketDetail.TicketId.ToString());

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "asd")
            };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                HttpContext.SignInAsync(principal);
                //return Json(new { success = true, message = "" });
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        

        [HttpGet]
        public IActionResult TicketList(TicketListModel ticketListModel)
        {
            try
            {
                var userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
                var ticketList = _ticketService.GetAll();
                //   ticketListViewModel.TicketList = ticketList;

                var ticketListId = new List<TicketDetailDto>();
                foreach (var ticket in ticketList.Data.Tickets)
                {
                    if (userId == ticket.UserId&&ticket.StatusId==1)
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
                //  ticketListViewModel.TicketList.Data.Tickets = ticketListId;
                return View(ticketListModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(PhotoDto photoDto)
        {
            //string wwwRootPath = _hostEnvironment.WebRootPath;
            //string fileName = Path.GetFileNameWithoutExtension(photoDto.PhotoAddDto.ImageFile.FileName);
            //string extension = Path.GetFileNameWithoutExtension(photoDto.PhotoAddDto.ImageFile.FileName);
            //photoDto.PhotoAddDto.PhotoName = fileName = fileName + DateTime.Now.ToString("yy-MM-dd") + extension;
            //string path = Path.Combine(wwwRootPath + "/Image/", fileName);
            //using (var fileStream = new FileStream(path, FileMode.Create))
            //{
            //    await photoDto.PhotoAddDto.ImageFile.CopyToAsync(fileStream);
            //}


            var userId = HttpContext.Session.GetString("UserId");

            photoDto.Ticket.StatusId = 1;
            photoDto.Ticket.UserId = Convert.ToInt32(userId);
            photoDto.Ticket.CreatedDate = System.DateTime.Now;

            var result = _ticketService.Add(photoDto.Ticket);
            // var  result = "asd";
            if (result != null)
            {
                return Json(new { success = true, message = "Talebiniz Oluşturuldu." });
            }
            return Json(new { success = false, message = "Talep oluşturulurken hata oluştu." });

        }

        [HttpPost]
        public async Task<IActionResult> AnswerAdd(TicketAnswer ticketAnswer)
        {
            try
            {
                //HttpContext.Session.SetString("TicketId", ticketAnswer.TicketId.ToString());
                ticketAnswer.CreatedDate = System.DateTime.Now;
                ticketAnswer.Name= HttpContext.Session.GetString("UserName");
                var result = _ticketAnswerService.Add(ticketAnswer);
                // var  result = "asd";
                if (result != null)
                {
                    return Json(new { success = true, message = "Talebiniz Oluşturuldu." });
                }
                return Json(new { success = false, message = "Talep oluşturulurken hata oluştu." });

                //return RedirectToAction("TicketList", "Ticket", new { area = "Employee" });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
      
        [HttpPost]
        public async Task<IActionResult> StatusUpdate(TicketUpdateDto ticketUpdateDto)
        {
            try
            {
                var result = _ticketService.TicketUpdate(ticketUpdateDto);


                return Json(new { success = true, message = "Durum Güncellendi" });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }
}
