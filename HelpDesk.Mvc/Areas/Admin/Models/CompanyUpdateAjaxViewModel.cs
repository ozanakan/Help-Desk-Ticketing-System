using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Entities.Dtos;

namespace HelpDesk.Mvc.Areas.Admin.Models
{
    public class CompanyUpdateAjaxViewModel
    {
        public CompanyAddDto CompanyUpdateDto { get; set; }
        public string CompanyUpdatePartial { get; set; }
        public CompanyDto CompanyDto { get; set; }


    }
}
