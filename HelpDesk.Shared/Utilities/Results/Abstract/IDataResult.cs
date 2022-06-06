using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T>:IResult
    {
        public T Data { get; } //new DataResult<Category>(ResultStatus.Success,category)       
                               //new DataResult<List<Category>>(ResultStatus.Success,categoryList)

    }
}
