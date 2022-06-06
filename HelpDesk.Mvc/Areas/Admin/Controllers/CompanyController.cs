using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HelpDesk.Entities.Dtos;
using HelpDesk.Mvc.Areas.Admin.Models;
using HelpDesk.Services.Abstract;
using HelpDesk.Shared.Utilities.Extensions;
using HelpDesk.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;

namespace HelpDesk.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {

        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        public IActionResult Index()
        {
            var result = _companyService.GetAll();
            return View(result.Data);
        }
       
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_CompanyAddPartial");
        }
      
        [HttpPost]
        public async Task<IActionResult> Add(CompanyAddDto companyAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = _companyService.Add(companyAddDto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var areaAddAjaxModel = JsonSerializer.Serialize(new CompanyAddAjaxViewModel
                    {
                          CompanyDto= result.Data,
                        CompanyAddPartial = await this.RenderViewToStringAsync("_CompanyAddPartial", companyAddDto)
                    });
                    return Json(areaAddAjaxModel);
                }
            }
            var areaAddAjaxError = JsonSerializer.Serialize(new CompanyAddAjaxViewModel
            {
                CompanyAddPartial = await this.RenderViewToStringAsync("_CompanyAddPartial", companyAddDto)
            });
            return Json(areaAddAjaxError);
        }
        public JsonResult GetAllCompany()
        {
            var result = _companyService.GetAll();
            var company = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(company);
        }
        public JsonResult Delete(int companyId)
        {
            var result = _companyService.Delete(companyId);
            var ajaxResult = JsonSerializer.Serialize(result);
            return Json(ajaxResult);
        }
      
        [HttpGet]
        public IActionResult Update(int areaId)
        {
            var result = _companyService.GetCompanyUpdateDto(areaId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return PartialView("_CompanyUpdatePartial", result.Data);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompanyUpdateDto companyUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = _companyService.Update(companyUpdateDto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var areaUpdateAjaxModel = JsonSerializer.Serialize(new CompanyUpdateAjaxViewModel
                    {
                        CompanyDto = result.Data,
                        CompanyUpdatePartial = await this.RenderViewToStringAsync("_CompanyUpdatePartial", companyUpdateDto)
                    });
                    return Json(areaUpdateAjaxModel);
                }
            }
            var companyUpdateAjaxError = JsonSerializer.Serialize(new CompanyUpdateAjaxViewModel
            {
                CompanyUpdatePartial = await this.RenderViewToStringAsync("_CompanyUpdatePartial", companyUpdateDto)
            });
            return Json(companyUpdateAjaxError);
        }

    }
}
