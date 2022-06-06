using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Entities.Concrete;
using HelpDesk.Shared.Data.Abstract;
using Microsoft.AspNetCore.Identity;

namespace HelpDesk.Data.Abstract
{
    public interface IRoleUserRepository : IEntityRepository<RoleUser>
    {

    }
}
