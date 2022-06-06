using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Entities.Concrete;
using HelpDesk.Shared.Entities.Abstract;

namespace HelpDesk.Entities.Dtos
{
    public class PhotoDto:DtoGetBase
    {
        public TicketAddDto Ticket { get; set; }
        public PhotoAddDto PhotoAddDto { get; set; }
    }
}
