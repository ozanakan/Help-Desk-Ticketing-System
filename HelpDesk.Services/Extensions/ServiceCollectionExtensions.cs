using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Data.Abstract;
using HelpDesk.Data.Concrete.EntityFrameWork;
using HelpDesk.Data.Concrete.EntityFrameWork.Contexts;
using HelpDesk.Services.Abstract;
using HelpDesk.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;


namespace HelpDesk.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<HelpDeskContext>();
            //serviceCollection.AddIdentity<User, Role>(options =>
            //{
            //    options.Password.RequireDigit = false;//şifre rakam içermek zorunda değil
            //    options.Password.RequiredLength = 5;
            //    options.Password.RequiredUniqueChars = 0;//özel karakter sayısı
            //    options.Password.RequireNonAlphanumeric = false;//özel karakter gerek yok
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireUppercase = false;
            //    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            //    options.User.RequireUniqueEmail = true;
            //}).AddEntityFrameworkStores<PlcContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICompanyService, CompanyManager>();
            serviceCollection.AddScoped<IEmployeeService, EmployeeManager>();
            serviceCollection.AddScoped<ITicketService, TicketManager>();
            serviceCollection.AddScoped<ITicketAnswerService, TicketAnswerManager>();
            serviceCollection.AddScoped<IRoleUserService,RoleUserManager>();


            return serviceCollection;
        }
    }
}
