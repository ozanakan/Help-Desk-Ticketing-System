using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDesk.Data.Concrete.EntityFrameWork.Repositories;
using HelpDesk.Entities.Dtos;
using System.Text.Json;
using System.Text.Json.Serialization;
using HelpDesk.Data.Concrete.EntityFrameWork.Contexts;
using HelpDesk.Mvc.Areas.Admin.Models;
using HelpDesk.Services.Abstract;
using HelpDesk.Shared.Utilities.Extensions;
using HelpDesk.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;

namespace HelpDesk.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICompanyService _companyService;
        private readonly HelpDeskContext _helpDeskContext;
        private readonly IRoleUserService _roleUserService;


        public EmployeeController(IEmployeeService employeeService, ICompanyService companyService, HelpDeskContext helpDeskContext, IRoleUserService roleUserService)
        {
            _employeeService = employeeService;
            _companyService = companyService;
            _helpDeskContext = helpDeskContext;
            _roleUserService = roleUserService;
        }


        public IActionResult Index(UserListViewModel userListViewModel)
        {
            var userList = _employeeService.GetAll();
            var companyList = _companyService.GetAll();
            userListViewModel.UserList = userList;
            userListViewModel.CompanyList = companyList;
            var userViewList = _helpDeskContext.UserCompanyViews.ToList();
            userListViewModel.UserCompanyViewList = userViewList;
            return View(userListViewModel);

            //return View(result.Data);Microsoft.Data.SqlClient.SqlException: 'Invalid object name 'UserViews'.'

        }

        //[HttpGet]
        //public IActionResult Add()
        //{



        //    return null;
        //}

        [HttpPost]
        public IActionResult Add(UserAddDto userAddDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userAddDto.RoleId = 1;
                    var result = _employeeService.Add(userAddDto);
                   
                    var roleUserAddDto = new RoleUserAddDto
                    {
                        RoleId = 2,
                        UserId = result.Data.User.Id
                    };
                    _roleUserService.Add(roleUserAddDto);
                    if (result.ResultStatus == ResultStatus.Success)
                    {
                        return Json(new { success = true, result = result.Message });
                    }
                }
                return Json(new { success = true, result = "Başarısız Ekleme İşlemi" });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        //[HttpPost]
        //public IActionResult Add(string name, string email)
        //{



        //    return null;
        //}



    }
}
