using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDiscussionDal:EfEntityRepositoryBase<Discussion,MathContext>,IDiscussionDal
    {
       
        /*public List<Answer> GetAnswers()
        {
            throw new NotImplementedException();
        }*/

        private static List<Tag> GetTags(int[] tags)
        {
            using var context = new MathContext();

            var tagsList = new List<Tag>();
            foreach (var id in tags)
            {
                var tag = context.Tags.SingleOrDefault(t=>t.Id==id);
                tagsList.Add(tag);
            }
            return tagsList;
        }

        public IPaginate<DiscussionDetailForListDto> GetDetailsForList(Expression<Func<DiscussionDetailForListDto, bool>> filter = null, Func<IQueryable<DiscussionDetailForListDto>, IOrderedQueryable<DiscussionDetailForListDto>> orderBy = null, int index = 0, int size = 15, bool enableTracking = false)
        {
            using var context = new MathContext();

            var result = from d in context.Discussions
                join user in context.Users on d.UserId equals user.Id
                join forum in context.Forums on d.ForumId equals forum.Id
                select new DiscussionDetailForListDto
                {
                    CreatedAt = d.CreatedAt,
                    ForumName = forum.Name,
                    ForumSlug = forum.Slug,
                    Id = d.Id,
                    Tags = GetTags(d.Tags),
                    LastModified = d.LastModified,
                    Messages = 0,
                    Slug = d.Slug,
                    Title = d.Title,
                    UserId = user.Id,
                    Username = user.UserName,
                    Views = 0,
                    Vote = 0
                };
            if(orderBy!=null)
                return orderBy(result).ToPaginate(index,size);
            return result.OrderByDescending(d => d.CreatedAt).ToPaginate(index, size);
        }

        public DiscussionDetailForListDto GetDetailBySlug(string slug)
        {
            using var context = new MathContext();

            var result = from d in context.Discussions.Where(d=>d.Slug==slug)
                join user in context.Users on d.UserId equals user.Id
                join forum in context.Forums on d.ForumId equals forum.Id
                select new DiscussionDetailForListDto
                {
                    CreatedAt = d.CreatedAt,
                    ForumName = forum.Name,
                    ForumSlug = forum.Slug,
                    Id = d.Id,
                    Tags = GetTags(d.Tags),
                    LastModified = d.LastModified,
                    Messages = 0,
                    Slug = d.Slug,
                    Title = d.Title,
                    UserId = user.Id,
                    Username = user.UserName,
                    Views = 0,
                    Vote = 0
                };
            return result.SingleOrDefault();
        }
    }
}
