using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Entities.Concrete;
using HelpDesk.Shared.Entities.Abstract;

namespace HelpDesk.Entities.Dtos
{
   public class TicketAnswerDto : DtoGetBase
    {
        public TicketAnswer TicketAnswer { get; set; }
    }
}
