using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTagDal : EfEntityRepositoryBase<Tag,MathContext>, ITagDal
    {

        public List<Tag> GetList(Expression<Func<Tag, bool>> filter = null)
        {
            using var context = new MathContext();
            return context.Tags.ToList();
        }
    }
}
