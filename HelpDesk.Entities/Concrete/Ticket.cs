using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Shared.Entities.Abstract;

namespace HelpDesk.Entities.Concrete
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }
        //public int AdminId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FinalDate { get; set; }
        //public string CreatedDate { get; set; }
        //public string FinalDate { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<TicketAnswer> TicketAnswer { get; set; }
        public virtual User User { get; set; }
        //public virtual Admin Admin { get; set; }
        public virtual Status Status { get; set; }


    }
}
