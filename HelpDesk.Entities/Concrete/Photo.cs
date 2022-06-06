using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Shared.Entities.Abstract;

namespace HelpDesk.Entities.Concrete
{
    public class Photo : IEntity
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Name { get; set; }

        public virtual Ticket Ticket { get; set; }


    }
}
