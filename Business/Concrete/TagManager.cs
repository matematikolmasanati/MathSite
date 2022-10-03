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
    public class TagManager : ITagService
    {
        private ITagDal _tagDal;

        public TagManager(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }

        public IResult Add(Tag tag)
        {
           _tagDal.Add(tag);
           return new SuccessResult();
        }

        public IResult Update(Tag tag)
        {
            _tagDal.Update(tag);
            return new SuccessResult();
        }

        public IResult Delete(Tag tag)
        {
            _tagDal.Delete(tag);
            return new SuccessResult();
        }

        public IDataResult<List<Tag>> GetList(Expression<Func<Tag, bool>> filter = null)
        {
            return new SuccessDataResult<List<Tag>>(_tagDal.GetList(filter));
        }
    }
}
