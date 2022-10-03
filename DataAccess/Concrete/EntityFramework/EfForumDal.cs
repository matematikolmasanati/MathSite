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
    public class EfForumDal:EfEntityRepositoryBase<Forum,MathContext>,IForumDal
    {
        public List<Forum> GetList(Expression<Func<Forum, bool>> filter = null)
        {
            using var context = new MathContext();
            return context.Forums.ToList();
        }
    }
}
