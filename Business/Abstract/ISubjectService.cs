using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISubjectService
    {
        IDataResult<IPaginate<Subject>> GetList(Expression<Func<Subject, bool>> filter,int index,int size,bool enableTracking);
    }
}
