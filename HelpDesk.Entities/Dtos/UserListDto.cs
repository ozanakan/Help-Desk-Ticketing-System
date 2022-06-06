using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Shared.Entities.Abstract;

namespace HelpDesk.Entities.Dtos
{
    public class UserListDto : DtoGetBase
    {
        public List<UserDetailDto> Users { get; set; }
    }
}
