using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Entities.Concrete;
using HelpDesk.Entities.Dtos;

namespace HelpDesk.Mvc.Areas.Employee.Models
{
    public class TicketListModel
    {
        public List<TicketDetailDto> Tickets { get; set; }
        public List<TicketAnswer> TicketAnswers { get; set; }

    }
}
