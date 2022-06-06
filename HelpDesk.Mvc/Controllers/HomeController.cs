using HelpDesk.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HelpDesk.Data.Concrete.EntityFrameWork.Contexts;
using HelpDesk.Entities.Concrete;
using HelpDesk.Entities.Dtos;
using HelpDesk.Services.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace HelpDesk.Mvc.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService _employeeService;
        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;
        public HomeController(ILogger<HomeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Index(UserDetailDto userDetailDto)
        //{
        //    var userList = _employeeService.GetAll();

        //    foreach (var user in userList.Data.Users)
        //    {
        //        if (user.Email == userDetailDto.Email&& user.Password == userDetailDto.Password)
        //        {

        //            HttpContext.Session.SetString("UserName", user.Email);

        //            var claims = new List<Claim>
        //            {
        //                new Claim(ClaimTypes.Name, user.UserName)
        //            };
        //            var useridentity = new ClaimsIdentity(claims, "a");
        //            ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
        //            await HttpContext.SignInAsync(principal);
        //            return RedirectToAction("Index", "Home", new { area = "Employee" });
        //        }

        //    }
        //    //var mail = "ozanakan@gmail";
        //    //HttpContext.Session.SetString("UserName", mail);
        //    return RedirectToAction("Index", "Writer");
        // //   return RedirectToAction("Index", "Home", new { area = "Admin" });
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Index(UserDetailDto userDetailDto)
        //{
        //    var userList = _employeeService.GetAll();
        //    HelpDeskContext c = new HelpDeskContext();
        //    var data = c.Users.FirstOrDefault(x =>
        //        x.Email == userDetailDto.Email && x.Password == userDetailDto.Password);

        //    if (data != null)
        //    {
        //        var claims = new List<Claim>
        //                {
        //                    new Claim(ClaimTypes.Name, userDetailDto.Email)
        //                };
        //        var useridentity = new ClaimsIdentity(claims, "a");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
        //        await HttpContext.SignInAsync(principal);
        //        return RedirectToAction("Index", "Home", new { area = "Employee" });
        //    }


        //    foreach (var user in userList.Data.Users)
        //    {
        //        if (user.Email == userDetailDto.Email && user.Password == userDetailDto.Password)
        //        {

        //        HttpContext.Session.SetString("UserName", user.UserName);

        //            var claims = new List<Claim>
        //            {
        //                new Claim(ClaimTypes.Name, user.UserName)
        //            };
        //            var useridentity = new ClaimsIdentity(claims, "a");
        //            ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
        //            HttpContext.SignInAsync(principal);
        //            return RedirectToAction("Index", "Home", new {area = "Employee"});
        //        }
        //    }
        //    return RedirectToAction("Index", "Writer");
        //    return RedirectToAction("Index", "Home", new { area = "Employee" });
        //}


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(UserDetailDto userDetailDto)
        {
            HelpDeskContext c = new HelpDeskContext();
            var data = c.Users.FirstOrDefault(x =>
                    x.Email == userDetailDto.Email && x.Password == userDetailDto.Password);

            if (data != null)
            {
                try
                {
                    HttpContext.Session.SetString("UserId", data.Id.ToString());
                    HttpContext.Session.SetString("UserName", data.Name);
                    HttpContext.Session.SetString("UserEmail", data.Id.ToString());

                    var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, userDetailDto.Email)
                            };
                    var useridentity = new ClaimsIdentity(claims, "a");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Home", new { area = "Employee" });

                }
                catch (Exception e)
                {
                    throw;
                }


            }
            // return RedirectToAction("Index", "Home", new { area = "Admin" });
            return Json(Url.Action("Index", "Home", new { area = "Employee" }));
        }


        //[AllowAnonymous]
        //[HttpPost]
        //public ActionResult Index(UserDetailDto userDetailDto)
        //{
        //    HelpDeskContext c = new HelpDeskContext();
        //    var data = c.Users.FirstOrDefault(x =>
        //        x.Email == userDetailDto.Email && x.Password == userDetailDto.Password);

        //    if (data != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, userDetailDto.Email)
        //        };
        //        var useridentity = new ClaimsIdentity(claims, "a");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
        //        //await HttpContext.SignInAsync(principal);
        //        //return RedirectToAction("Index", "Home", new { area = "Employee" });
        //    }
        //    return RedirectToAction("Index", "Home", new { area = "Admin" });
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
