using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IUserOperationClaimService _userOperationClaimService;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimService operationClaimService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userOperationClaimService = operationClaimService;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                UserName = userForRegisterDto.Username,
                Name = userForRegisterDto.Name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                PicturePath = "default.png"
            };
            _userService.Add(user);
            _userOperationClaimService.Add(new UserOperationClaim { OperationClaimId = 3, UserId = user.Id });
            return new SuccessDataResult<User>(user, "");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            User userToCheck = IsEmail(userForLoginDto) ? _userService.GetByEmail(userForLoginDto.EmailOrUsername) : _userService.GetByUsername(userForLoginDto.EmailOrUsername);

            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash,
                    userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.WrongPassword);
            }

            return new SuccessDataResult<User>(userToCheck);
        }

        public IResult UserExists(string email, string username)
        {
            if (_userService.GetByEmail(email) != null || _userService.GetByUsername(username) != null)
            {
                return new ErrorResult(Messages.UserExists);
            }
            return new SuccessResult();
        }


        public IDataResult<AccessToken> CreateToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken);

        }

        private bool IsEmail(UserForLoginDto user)
        {
            return user.EmailOrUsername.Contains("@");
        }

    }

   
}
