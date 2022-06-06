using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HelpDesk.Data.Abstract;
using HelpDesk.Data.Concrete.EntityFrameWork.Contexts;
using HelpDesk.Entities.Concrete;
using HelpDesk.Entities.Dtos;
using HelpDesk.Services.Abstract;
using HelpDesk.Shared.Utilities.Results.Abstract;
using HelpDesk.Shared.Utilities.Results.ComplexTypes;
using HelpDesk.Shared.Utilities.Results.Concrete;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace HelpDesk.Services.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public IDataResult<UserDto> Add(UserAddDto userAddDto)
        {
            var user = _mapper.Map<User>(userAddDto);
            var addedUser = _unitOfWork.Users.Add(user);
            _unitOfWork.Save();
            return new DataResult<UserDto>(
                ResultStatus.Success, $"{userAddDto.Name} Başarıyla Eklenmiştir.", new UserDto
                {
                    User = addedUser,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{userAddDto.Name} Başarıyla Eklenmiştir."
                });
        }

        public IDataResult<UserListDto> GetAll()
        {
            using (HelpDeskContext context = new HelpDeskContext())
            {
                var result =
                             from U in context.Users
                             join C in context.Companies
                                 on U.CompanyId equals C.Id
                             join R in context.Roles
                                 on U.Id equals R.Id
                             //join A in context.Admins
                             //    on U.AdminId equals A.Id

                           


                             select new UserDetailDto
                             {
                                 UserId = U.Id,
                                 UserName = U.Name,
                                 Email = U.Email,
                                 Password = U.Password,
                                 //CompanyId = C.Id,
                                 RoleId = R.Id,
                                 //CompanyName = C.Name,
                                 RoleName = R.Name,
                                 //AdminId = A.Id,
                                 //AdminName = A.Name
                             };
                //return result.ToList();
                var listEmployee = result.ToList();


                if (listEmployee.Count > -1)
                {
                    return new DataResult<UserListDto>(ResultStatus.Success, new UserListDto
                    {
                        Users = listEmployee,
                        ResultStatus = ResultStatus.Success
                    });
                }
                return new DataResult<UserListDto>(ResultStatus.Error, "Hiç bir değer bulunamadı", new UserListDto
                {
                    Users = null,
                    ResultStatus = ResultStatus.Error,
                    Message = "Hiç bir değer bulunamadı."
                });
            }
        }













    }
}
