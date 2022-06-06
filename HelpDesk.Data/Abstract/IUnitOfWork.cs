using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Data.Abstract
{
   public interface IUnitOfWork: IDisposable
    {
        ICompanyRepository Companies { get; }
        IUserRepository Users { get; }
        ITicketRepository Tickets { get; }
        ITicketAnswerRepository TicketAnswers { get; }
        IRoleUserRepository RoleUsers { get; }
        int Save();
    }
}
