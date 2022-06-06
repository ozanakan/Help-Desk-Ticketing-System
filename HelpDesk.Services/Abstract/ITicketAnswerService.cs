using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Entities.Concrete;
using HelpDesk.Entities.Dtos;
using HelpDesk.Shared.Utilities.Results.Abstract;

namespace HelpDesk.Services.Abstract
{
    public interface ITicketAnswerService
    {
        IDataResult<TicketAnswerListDto> GetAll();
        IDataResult<TicketAnswerDto> Add(TicketAnswer ticketAnswer);
    }
}
