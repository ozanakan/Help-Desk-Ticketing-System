using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Shared.Entities.Abstract;

namespace HelpDesk.Entities.Dtos
{
    public class UserDetailDto
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }


    }
}
