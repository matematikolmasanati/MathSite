using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstracts;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,MathContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
           //LINQ
           using var context = new MathContext();
           var result = from operationClaim in context.OperationClaims
               join userOperationClaim in context.UserOperationClaims on operationClaim.Id equals
                   userOperationClaim.OperationClaimId
               where userOperationClaim.UserId == user.Id
               select new OperationClaim {Id = operationClaim.Id, Name = operationClaim.Name};
           return result.ToList();
        }

    }
}
