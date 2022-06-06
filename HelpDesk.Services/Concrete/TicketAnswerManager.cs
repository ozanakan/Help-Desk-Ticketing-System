using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HelpDesk.Data.Abstract;
using HelpDesk.Entities.Concrete;
using HelpDesk.Entities.Dtos;
using HelpDesk.Services.Abstract;
using HelpDesk.Shared.Utilities.Results.Abstract;
using HelpDesk.Shared.Utilities.Results.ComplexTypes;
using HelpDesk.Shared.Utilities.Results.Concrete;

namespace HelpDesk.Services.Concrete
{
    public class TicketAnswerManager : ITicketAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
      

        public TicketAnswerManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public IDataResult<TicketAnswerDto> Add(TicketAnswer ticketAnswer)
        {
            var ticket = _mapper.Map<TicketAnswer>(ticketAnswer);
            var addedTicket = _unitOfWork.TicketAnswers.Add(ticket);
            _unitOfWork.Save();
            return new DataResult<TicketAnswerDto>(
                ResultStatus.Success, $"{ticketAnswer.Id} Başarıyla Eklenmiştir.", new TicketAnswerDto
                {
                    TicketAnswer = addedTicket,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{ticketAnswer.Id} Başarıyla Eklenmiştir."
                });
        }

        public IDataResult<TicketAnswerListDto> GetAll()
        {
            var listCompany = _unitOfWork.TicketAnswers.GetAll(null);
            if (listCompany.Count > -1)
            {
                return new DataResult<TicketAnswerListDto>(ResultStatus.Success, new TicketAnswerListDto
                {
                    TicketAnswer = listCompany,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<TicketAnswerListDto>(ResultStatus.Error, "Hiç bir değer bulunamadı", new TicketAnswerListDto
            {
                TicketAnswer = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hiç bir değer bulunamadı."
            });
        }

     
    }
}
