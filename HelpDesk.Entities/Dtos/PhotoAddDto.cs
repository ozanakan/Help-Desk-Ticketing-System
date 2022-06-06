using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HelpDesk.Entities.Dtos
{
    public class PhotoAddDto
    {
        public int TicketId { get; set; }
        public int PhotoId { get; set; }
        public string PhotoName { get; set; }
        public IFormFile ImageFile { get; set; }

    }
}
