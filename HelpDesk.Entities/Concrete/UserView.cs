using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Entities.Concrete
{
    [Keyless]
    public class UserView
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int AdminId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }

    }
}
