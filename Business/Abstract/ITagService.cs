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
    public interface ITagService
    {
        IResult Add(Tag tag);
        IResult Update(Tag tag);
        IResult Delete(Tag tag);
        IDataResult<List<Tag>> GetList(Expression<Func<Tag, bool>> filter = null);
    }
}
