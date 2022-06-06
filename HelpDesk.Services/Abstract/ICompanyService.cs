using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Entities.Dtos;
using HelpDesk.Shared.Utilities.Results.Abstract;

namespace HelpDesk.Services.Abstract
{
    public interface ICompanyService
    {
        IDataResult<CompanyListDto> GetAll();
        IDataResult<CompanyDto> Add(CompanyAddDto companyAddDto);
        IDataResult<CompanyUpdateDto> GetCompanyUpdateDto(int companyId);
        IDataResult<CompanyDto> Update(CompanyUpdateDto companyUpdateDto);
        IResult Delete(int companyId);

    }
}
