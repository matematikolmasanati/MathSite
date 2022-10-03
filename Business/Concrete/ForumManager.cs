using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ForumManager:IForumService
    {
        private IForumDal _forumDal;

        public ForumManager(IForumDal forumDal)
        {
            _forumDal = forumDal;
        }

        public IResult Add(Forum forum)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Forum forum)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Forum forum)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Forum>> GetList(Expression<Func<Forum, bool>> filter = null)
        {
            return new SuccessDataResult<List<Forum>>(_forumDal.GetList(filter));
        }
    }
}
