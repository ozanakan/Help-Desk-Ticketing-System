using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Shared.Entities.Abstract;

namespace HelpDesk.Entities.Concrete
{
    public class TicketAnswer : IEntity
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Answer { get; set; }
        public string Name { get; set; }    
        public DateTime CreatedDate { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
