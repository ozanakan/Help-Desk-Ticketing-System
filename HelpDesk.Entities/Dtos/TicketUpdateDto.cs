﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Entities.Dtos
{
    public class TicketUpdateDto
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        //public int UserId { get; set; }
        //public string Title { get; set; }
        //public string Description { get; set; }
        //public DateTime CreatedDate { get; set; }
        public DateTime FinalDate { get; set; }

    }
}
