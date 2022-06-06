using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Data.Abstract;
using HelpDesk.Data.Concrete.EntityFrameWork.Contexts;
using HelpDesk.Entities.Concrete;
using HelpDesk.Entities.Dtos;
using HelpDesk.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Data.Concrete.EntityFrameWork.Repositories
{
    public class EfUserRepository : EfEntityRepositoryBase<User>, IUserRepository
    {

        public EfUserRepository(HelpDeskContext context) : base(context)
        {
            //List<UserDetailDto> GetUserDetails()
            //{
            //    var result = from U in context.Users
            //                 join C in context.Companies
            //                    on U.CompanyId equals C.Id
            //                 join R in context.Roles
            //                 on U.RoleId equals R.Id
            //                 select new UserDetailDto
            //                 {
            //                     UserId = U.Id,
            //                     UserName = U.Name,
            //                     Email = U.Email,
            //                     Password = U.Password,
            //                     CompanyId = C.Id,
            //                     RoleId = R.Id,
            //                     CompanyName = C.Name,
            //                     RoleName = R.Name
            //                 };
            //    return result.ToList();
            //}
        }
    }
}
