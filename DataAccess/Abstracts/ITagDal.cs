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
    public interface ITagDal : IEntityRepository<Tag>
    {
        List<Tag> GetList(Expression<Func<Tag, bool>> filter = null);
    }
}
