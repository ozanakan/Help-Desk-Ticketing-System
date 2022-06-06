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
    public class CompanyManager : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IDataResult<CompanyDto> Add(CompanyAddDto companyAddDto)
        {
            var company = _mapper.Map<Company>(companyAddDto);
            var addedCompany = _unitOfWork.Companies.Add(company);
            _unitOfWork.Save();
            return new DataResult<CompanyDto>(
                ResultStatus.Success, $"{companyAddDto.Name} Başarıyla Eklenmiştir.", new CompanyDto
                {
                    Company = addedCompany,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{companyAddDto.Name} Başarıyla Eklenmiştir."
                });
        }
        public IDataResult<CompanyListDto> GetAll()
        {
            var listCompany = _unitOfWork.Companies.GetAll(null);
            if (listCompany.Count > -1)
            {
                return new DataResult<CompanyListDto>(ResultStatus.Success, new CompanyListDto
                {
                    Companies = listCompany,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CompanyListDto>(ResultStatus.Error, "Hiç bir değer bulunamadı", new CompanyListDto
            {
                Companies = null,
                ResultStatus = ResultStatus.Error,
                Message = "Hiç bir değer bulunamadı."
            });
        }

        public IDataResult<CompanyDto> Update(CompanyUpdateDto companyUpdateDto)
        {
            var area = _mapper.Map<Company>(companyUpdateDto);
            var updateArea = _unitOfWork.Companies.Update(area);
            _unitOfWork.Save();
            return new DataResult<CompanyDto>(ResultStatus.Success, $"{companyUpdateDto.Name} Başarıyla Güncellenmiştir.", new CompanyDto()
            {
                Company = updateArea,
                ResultStatus = ResultStatus.Success,
                Message = $"{companyUpdateDto.Name} Başarıyla Eklenmiştir."
            });
        }

        public IResult Delete(int companyId)
        {
            var result = _unitOfWork.Companies.Any(a => a.Id == companyId);
            if (result)
            {
                var company = _unitOfWork.Companies.Get(a => a.Id == companyId);
                _unitOfWork.Companies.Delete(company);
                _unitOfWork.Save();
                return new Result(ResultStatus.Success, $"{company.Name} Başarıyla Silinmiştir.");
            }
            return new Result(ResultStatus.Success, "Böyle bir kayıt bulunamadı.");
        }

        public IDataResult<CompanyUpdateDto> GetCompanyUpdateDto(int companyId)
        {
            var company = _unitOfWork.Companies.Get(c => c.Id == companyId);
            if (company != null)
            {
                var companyUpdateDto = _mapper.Map<CompanyUpdateDto>(company);
                return new DataResult<CompanyUpdateDto>(ResultStatus.Success, companyUpdateDto);
            }
            return new DataResult<CompanyUpdateDto>(ResultStatus.Error, "Böyle Bir Area Bulunamadı.", null);

        }
    }
}
