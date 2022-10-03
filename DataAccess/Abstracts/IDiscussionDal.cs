using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstracts
{
    public interface IDiscussionDal:IEntityRepository<Discussion>
    {
       // List<Answer> GetAnswers();
       IPaginate<DiscussionDetailForListDto> GetDetailsForList(
           Expression<Func<DiscussionDetailForListDto, bool>> filter = null, Func<IQueryable<DiscussionDetailForListDto>, IOrderedQueryable<DiscussionDetailForListDto>> orderBy = null, int index = 0, int size = 15,
           bool enableTracking = false);
       DiscussionDetailForListDto GetDetailBySlug(string slug);
    }
}
