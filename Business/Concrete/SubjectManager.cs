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
    public class SubjectManager:ISubjectService
    {
        private ISubjectDal _subjectDal;

        public SubjectManager(ISubjectDal subjectDal)
        {
            _subjectDal = subjectDal;
        }

        public IDataResult<IPaginate<Subject>> GetList(Expression<Func<Subject, bool>> filter,int index,int size,bool enableTracking)
        {
            return new SuccessDataResult<IPaginate<Subject>>(_subjectDal.GetList(filter,null,index,size,enableTracking));
        }
    }
}
