using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IDiscussionService
    {
        IResult Add(Discussion discussion);
        IResult Delete(Discussion discussion);
        IResult Update(Discussion discussion);
        IDataResult<DiscussionDetailForListDto> GetBySlug(string slug);
        IDataResult<IPaginate<Discussion>> GetList(Expression<Func<Discussion, bool>> filter = null);
        IDataResult<IPaginate<DiscussionDetailForListDto>> GetDetailForList(Expression<Func<DiscussionDetailForListDto, bool>> filter = null, Func<IQueryable<DiscussionDetailForListDto>, IOrderedQueryable<DiscussionDetailForListDto>> orderBy = null, int index=0,int size=15,bool enableTracking=false);
    }
}
