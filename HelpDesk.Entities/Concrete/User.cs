using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Shared.Entities.Abstract;

namespace HelpDesk.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        //public int RoleId { get; set; }
        public int AdminId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual Company Company { get; set; }
        // public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
