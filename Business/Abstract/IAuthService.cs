using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto user, string password);
        IDataResult<User> Login(UserForLoginDto user);
        IResult UserExists(string email,string username);
        IDataResult<AccessToken> CreateToken(User user);

    }
}
