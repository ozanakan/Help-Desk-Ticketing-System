using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Data.Abstract;
using HelpDesk.Data.Concrete.EntityFrameWork.Contexts;
using HelpDesk.Entities.Concrete;
using HelpDesk.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Data.Concrete.EntityFrameWork.Repositories
{
    public class EfPhotoRepository : EfEntityRepositoryBase<Photo>, IPhotoRepository
    {
        public EfPhotoRepository(HelpDeskContext context) : base(context)
        {

        }
    }
}
