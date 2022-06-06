using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Data.Abstract;
using HelpDesk.Data.Concrete.EntityFrameWork.Contexts;
using HelpDesk.Data.Concrete.EntityFrameWork.Repositories;

namespace HelpDesk.Data.Concrete.EntityFrameWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HelpDeskContext _context;
        private EfCompanyRepository _companyRepository;
        private EfUserRepository _userRepository;
        private EfTicketRepository _ticketRepository;
        private EfTicketAnswerRepository _ticketAnswerRepository;
        private EfRoleUserRepository _roleUserRepository;
        public UnitOfWork(HelpDeskContext context)
        {
            _context = context;
        }
        public ICompanyRepository Companies => _companyRepository ?? new EfCompanyRepository(_context);
    
        public IUserRepository Users => _userRepository ?? new EfUserRepository(_context);
        public ITicketRepository Tickets => _ticketRepository ?? new EfTicketRepository(_context);
        public ITicketAnswerRepository TicketAnswers => _ticketAnswerRepository ?? new EfTicketAnswerRepository(_context);
        public IRoleUserRepository RoleUsers => _roleUserRepository ?? new EfRoleUserRepository(_context);
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
