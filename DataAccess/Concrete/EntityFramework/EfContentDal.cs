using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfContentDal : EfEntityRepositoryBase<Content,MathContext>,IContentDal
    {
        public IPaginate<ContentDetailDto> GetContentDetailDtos(Expression<Func<ContentDetailDto, bool>> filter,int index, int size,bool enableTracking)
        {
            using var context = new MathContext();
            
            var result = from c in context.Contents
                join u in context.Users on c.UserId equals u.Id
                join uoc in context.UserOperationClaims on u.Id equals uoc.UserId
                join oc in context.OperationClaims on uoc.OperationClaimId equals oc.Id
                select new ContentDetailDto
                {
                    Title = c.Title,
                    Description = c.Description,
                    Photos = c.Photos,
                    CreatedAt = c.CreatedAt,
                    Id = c.Id,
                    Slug = c.Slug,
                    UserName = u.Name,
                    UserOperationClaimName = oc.Name
                };
            return result.Where(filter ?? (c=>true)).ToPaginate(index,size);



        }
    }
}
