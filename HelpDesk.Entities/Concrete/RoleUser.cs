using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Shared.Entities.Abstract;

namespace HelpDesk.Entities.Concrete
{
    public class RoleUser : IEntity
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
