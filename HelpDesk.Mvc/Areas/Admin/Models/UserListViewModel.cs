using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Entities.Concrete;
using HelpDesk.Entities.Dtos;
using HelpDesk.Shared.Utilities.Results.Abstract;

namespace HelpDesk.Mvc.Areas.Admin.Models
{
    public class UserListViewModel
    {
        public IDataResult<UserListDto>UserList { get; set; }
        public IDataResult<CompanyListDto> CompanyList { get; set; }
        public List<UserView> UserViewList { get; set; }
        public List<UserCompanyView> UserCompanyViewList { get; set; }

        public UserAddDto UserAddDto { get; set; }
    }
}
