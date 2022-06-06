using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HelpDesk.Entities.Concrete;
using HelpDesk.Entities.Dtos;

namespace HelpDesk.Services.AutoMapper.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyAddDto, Company>();
            CreateMap<CompanyUpdateDto, Company>();
            CreateMap<Company, CompanyUpdateDto>();
        }
    }
}