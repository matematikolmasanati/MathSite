using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IContentService
    {
        IResult Add(Content content);
        IResult Update(Content content);
        IResult Delete(Content content);
        IDataResult<Content> Get(Expression<Func<Content, bool>> filter);
        IDataResult<IPaginate<Content>> GetList(Expression<Func<Content, bool>> filter, Func<IQueryable<Content>, IOrderedQueryable<Content>> orderBy, int index, int size, bool enableTracking);
        IDataResult<IPaginate<Content>> GetByUserId(int userId);
        IDataResult<IPaginate<ContentDetailDto>> GetContentDetails(Expression<Func<ContentDetailDto, bool>> filter=null, Func<IQueryable<ContentDetailDto>, IOrderedQueryable<ContentDetailDto>> orderBy=null, int index=0, int size=10, bool enableTracking=false);

    }

}
