using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Data.Abstract;
using HelpDesk.Data.Concrete.EntityFrameWork.Contexts;
using HelpDesk.Entities.Concrete;
using HelpDesk.Shared.Data.Concrete.EntityFramework;

namespace HelpDesk.Data.Concrete.EntityFrameWork.Repositories
{
  public  class EfTicketAnswerRepository : EfEntityRepositoryBase<TicketAnswer>, ITicketAnswerRepository
    {
        public EfTicketAnswerRepository(HelpDeskContext context) : base(context)
        {

        }
    }
}
