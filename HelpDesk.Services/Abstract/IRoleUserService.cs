using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Entities.Dtos;
using HelpDesk.Shared.Utilities.Results.Abstract;

namespace HelpDesk.Services.Abstract
{
  public  interface IRoleUserService
    {
        IDataResult<RoleUserDto> Add(RoleUserAddDto roleUserAddDto);
    }
}
