using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HelpDesk.Data.Abstract;
using HelpDesk.Entities.Concrete;
using HelpDesk.Entities.Dtos;
using HelpDesk.Services.Abstract;
using HelpDesk.Shared.Utilities.Results.Abstract;
using HelpDesk.Shared.Utilities.Results.ComplexTypes;
using HelpDesk.Shared.Utilities.Results.Concrete;

namespace HelpDesk.Services.Concrete
{
    public class RoleUserManager : IRoleUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleUserManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IDataResult<RoleUserDto> Add(RoleUserAddDto roleUserAddDto)
        {
            try
            {

                var roleUser = _mapper.Map<RoleUser>(roleUserAddDto);
                var addedRoleUser = _unitOfWork.RoleUsers.Add(roleUser);
                _unitOfWork.Save();
                return new DataResult<RoleUserDto>(
                    ResultStatus.Success, $"{roleUserAddDto.RoleId} Başarıyla Eklenmiştir.", new RoleUserDto
                    {
                        RoleUser = addedRoleUser,
                        ResultStatus = ResultStatus.Success
                    });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
