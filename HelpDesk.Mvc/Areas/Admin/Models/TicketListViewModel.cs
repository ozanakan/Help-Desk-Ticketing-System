using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Entities.Dtos;
using HelpDesk.Shared.Utilities.Results.Abstract;

namespace HelpDesk.Mvc.Areas.Admin.Models
{
    public class TicketListViewModel
    {
        public IDataResult<TicketListDto> TicketList { get; set; }
    }
}
