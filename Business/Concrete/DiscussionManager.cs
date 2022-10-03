using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Concrete
{
    public class DiscussionManager : IDiscussionService
    {

        private IDiscussionDal _discussionDal;
        private IHttpContextAccessor _httpContextAccessor;
        private IUserService _userService;

        public DiscussionManager(IDiscussionDal discussionDal, IUserService userService)
        {
            _discussionDal = discussionDal;
            _userService = userService;
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        [SecuredOperation("Admin,Moderatör,Üye,Öğretmen,Muallim,Kıdemli Üye,Öğrenci,Talebe")]
        public IResult Add(Discussion discussion)
        {
            discussion.CreatedAt=DateTime.Now;
            discussion.UserId = getCurrentUser().Id;
            discussion.Slug = discussion.Title.ToSlug();
            var i = 0;
            while (checkSlug(discussion.Slug)==false)
            {
                discussion.Slug = discussion.Title.ToSlug() + i;
                i++;
            }
            _discussionDal.Add(discussion);
            return new SuccessResult();
        }

        private bool checkSlug(string slug)
        {
          return  _discussionDal.Get(d => d.Slug == slug) == null;
        }

        public IResult Delete(Discussion discussion)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Discussion discussion)
        {
            throw new NotImplementedException();
        }

        public IDataResult<DiscussionDetailForListDto> GetBySlug(string slug)
        {
            var discussion = _discussionDal.GetDetailBySlug(slug);
            if (discussion == null)
            {
                return new ErrorDataResult<DiscussionDetailForListDto>();
            }

            return new SuccessDataResult<DiscussionDetailForListDto>(discussion);
        }

        public IDataResult<IPaginate<Discussion>> GetList(Expression<Func<Discussion, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IPaginate<DiscussionDetailForListDto>> GetDetailForList(Expression<Func<DiscussionDetailForListDto, bool>> filter = null, Func<IQueryable<DiscussionDetailForListDto>, IOrderedQueryable<DiscussionDetailForListDto>>? orderBy = null, int index = 0, int size = 15, bool enableTracking = false)
        {
            return new SuccessDataResult<IPaginate<DiscussionDetailForListDto>>(
                _discussionDal.GetDetailsForList(filter,orderBy, index, size, enableTracking));
        }

        private User getCurrentUser()
        {
            return _userService.Get(u => u.Id == int.Parse(_httpContextAccessor.HttpContext.User.Claims(ClaimTypes.NameIdentifier)[0])).Data;
        }
    }
}
