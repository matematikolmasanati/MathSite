using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concrete;
using Entities.Dtos;
// ReSharper disable All

namespace Business.Concrete
{
    public class ContentManager : IContentService
    {
        private IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        [SecuredOperation("Moderatör,Admin")]
        public IResult Add(Content content)
        {
            _contentDal.Add(content);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        [SecuredOperation("Admin,Moderatör")]
        public IResult Update(Content content)
        {
            _contentDal.Update(content);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }

        [SecuredOperation("Admin,Moderatör")]
        public IResult Delete(Content content)
        {
            _contentDal.Delete(content);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

        public IDataResult<Content> Get(Expression<Func<Content, bool>> filter)
        {
            return new SuccessDataResult<Content>(_contentDal.Get(filter));
        }
        [SecuredOperation("Admin,Moderatör")]
        public IDataResult<IPaginate<Content>> GetList(Expression<Func<Content, bool>> filter, Func<IQueryable<Content>, IOrderedQueryable<Content>> orderBy = null, int index=0, int size=10, bool enableTracking=false)
        {
            return new SuccessDataResult<IPaginate<Content>>(_contentDal.GetList(filter,orderBy,index,size,enableTracking));
        }

        public IDataResult<IPaginate<Content>> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IPaginate<ContentDetailDto>> GetContentDetails(Expression<Func<ContentDetailDto, bool>> filter=null, Func<IQueryable<ContentDetailDto>, IOrderedQueryable<ContentDetailDto>> orderBy = null, int index=0, int size=15, bool enableTracking=false)
        {
            return new SuccessDataResult<IPaginate<ContentDetailDto>>(_contentDal.GetContentDetailDtos(filter,index,size,enableTracking));
        }
    }
}
