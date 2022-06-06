using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Entities.Dtos
{
    public class TicketDetailDto
    {
        public int TicketId { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FinalDate { get; set; }
        public int AdminId { get; set; }
        public string AdminName { get; set; }
    }
}
