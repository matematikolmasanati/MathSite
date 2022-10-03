using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;

using Entities.Concrete;

namespace DataAccess.Abstracts
{
    public interface IForumDal : IEntityRepository<Forum>
    {
        List<Forum> GetList(Expression<Func<Forum, bool>> filter = null);
    }
}
