using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using AutoMapper;
using HelpDesk.Data.Abstract;
using HelpDesk.Data.Concrete.EntityFrameWork.Contexts;
using HelpDesk.Entities.Concrete;
using HelpDesk.Entities.Dtos;
using HelpDesk.Services.Abstract;
using HelpDesk.Shared.Utilities.Results.Abstract;
using HelpDesk.Shared.Utilities.Results.ComplexTypes;
using HelpDesk.Shared.Utilities.Results.Concrete;

namespace HelpDesk.Services.Concrete
{
    public class TicketManager : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;
        private readonly HelpDeskContext _helpDeskContext;

        public TicketManager(IUnitOfWork unitOfWork, IMapper mapper, IEmployeeService employeeService, HelpDeskContext helpDeskContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _employeeService = employeeService;
            _helpDeskContext = helpDeskContext;
        }

        public IDataResult<TicketDto> Add(TicketAddDto ticketAddDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketAddDto);
            var addedTicket = _unitOfWork.Tickets.Add(ticket);
            _unitOfWork.Save();
            return new DataResult<TicketDto>(
                ResultStatus.Success, $"{ticketAddDto.Title} Başarıyla Eklenmiştir.", new TicketDto
                {
                    Ticket = addedTicket,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{ticketAddDto.Title} Başarıyla Eklenmiştir."
                });
        }

        public IDataResult<TicketListDto> GetAll()
        {


            using (HelpDeskContext context = new HelpDeskContext())
            {
                var result = from T in context.Tickets
                             join U in context.Users
                                 on T.UserId equals U.Id
                             join S in context.Statuses
                                 on T.StatusId equals S.Id
                             //join A in context.Admins
                             //on U.AdminId equals A.Id
                             select new TicketDetailDto
                             {
                                 TicketId = T.Id,
                                 UserId = U.Id,
                                 UserName = U.Name,
                                 UserEmail = U.Email,
                                 Description = T.Description,
                                 Title = T.Title,
                                 StatusId = S.Id,
                                 StatusName = S.Name,
                                 CreatedDate = T.CreatedDate,
                                 FinalDate = T.FinalDate,
                                 //AdminId = A.Id,
                                 //AdminName = A.Name

                             };
                var listTicket = result.ToList();

                if (listTicket.Count > -1)
                {
                    return new DataResult<TicketListDto>(ResultStatus.Success, new TicketListDto
                    {
                        Tickets = listTicket,
                        ResultStatus = ResultStatus.Success
                    });
                }

                return new DataResult<TicketListDto>(ResultStatus.Error, "Hiç bir değer bulunamadı.",
                    new TicketListDto
                    {
                        Tickets = null,
                        ResultStatus = ResultStatus.Error,
                        Message = "Hiç bir değer bulunamadı."
                    });
            }


        }

        public IDataResult<TicketDto> TicketUpdate(TicketUpdateDto ticketUpdateDto)
        {

            var getTicket = _helpDeskContext.Tickets.FirstOrDefault(item => item.Id == ticketUpdateDto.Id);
            var ticket = _mapper.Map<Ticket>(getTicket);
            ticket.FinalDate = DateTime.Now;


            if (ticket.StatusId == 1)
            {
                ticket.StatusId = 2;
                var updateTicket = _unitOfWork.Tickets.Update(ticket);
                _unitOfWork.Save();
                return new DataResult<TicketDto>(ResultStatus.Success, $"{ticketUpdateDto.Id} Başarıyla Güncellenmiştir.", new TicketDto
                {
                    Ticket = updateTicket,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{ticketUpdateDto.Id} Başarıyla Eklenmiştir."
                });
            }
            if (ticket.StatusId == 2)
            {
                ticket.StatusId = 1;

                var updateTicket = _unitOfWork.Tickets.Update(ticket);
                _unitOfWork.Save();
                return new DataResult<TicketDto>(ResultStatus.Success, $"{ticketUpdateDto.Id} Başarıyla Güncellenmiştir.", new TicketDto
                {
                    Ticket = updateTicket,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{ticketUpdateDto.Id} Başarıyla Eklenmiştir."
                });

            }

            return null;
        }
    }
}
