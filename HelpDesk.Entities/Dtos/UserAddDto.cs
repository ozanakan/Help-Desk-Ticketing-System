using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Entities.Dtos
{
    public class UserAddDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int RoleId { get; set; }
        public string AdminId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
