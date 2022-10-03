using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;


namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<User> Get(Expression<Func<User, bool>> filter);
        IDataResult<IPaginate<User>> GetList(Expression<Func<User, bool>> filter,int index,int size,bool enableTracking);
        User GetByEmail(string email);
        User GetByUsername(string username);
        List<OperationClaim> GetClaims(User user);
        
    }
}
