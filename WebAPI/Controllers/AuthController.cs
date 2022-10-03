using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Claims;
using Business.Abstract;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Entities.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {

        private IAuthService _authService;
        private IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto user)
        {
            var userToLogin = _authService.Login(user);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }

            var token = _authService.CreateToken(userToLogin.Data);
            if (token.Success)
            {
                return Ok(token.Data);
            }

            return BadRequest(token);
        }

        [HttpPost("uploadImage")]
        public IActionResult UploadImage([FromForm] List<IFormFile> files)
        {
            var user = _userService.GetByEmail(User.FindFirstValue(ClaimTypes.Email));
            if (user == null)
                return Forbid();
            int maxContentLength = 1024 * 1024 * 1; //Size = 1 MB
            var oldProfilePictureExt = user.PicturePath.Substring(user.PicturePath.Length - Math.Min(4, user.PicturePath.Length)).ToLower();
            var ext = files[0].FileName.Substring(files[0].FileName.LastIndexOf('.')).ToLower();
            IList<string> allowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
            string directoryPath = Path.Combine(Path.GetPathRoot(Environment.SystemDirectory)!, "ProfileImages");
            string filePath = Path.Combine(directoryPath, user.Id.ToString() + ext);
            string fileName = user.Id.ToString() + ext;
            if (files.Count == 0)
                return BadRequest(new ErrorResult("Please provide a file"));

            if (!allowedFileExtensions.Contains(ext))
            {
                return BadRequest(new ErrorResult("Please upload image of type .jpg, .png, .gif"));
            }
            if (files[0].Length > maxContentLength)
            {
                return BadRequest(new ErrorResult("Please upload a file up to 1 mb."));
            }
            using var stream = new FileStream(filePath, FileMode.Create);
            if (!string.IsNullOrEmpty(user.PicturePath) && ext != oldProfilePictureExt)
                System.IO.File.Delete(user.PicturePath);
            files[0].CopyTo(stream);
            user.PicturePath = fileName;
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(new SuccessResult("Successfully uploaded"));
            }

            return BadRequest();
        }


        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto user)
        {
            var userExists = _authService.UserExists(user.Email, user.Username);
            if (!userExists.Success)
            {
                return BadRequest(userExists);
            }


            /*IDataResult<User>*/
            var registerResult = _authService.Register(user, user.Password);
            var token = _authService.CreateToken(registerResult.Data);
            if (token.Success)
            {
                return Ok(token.Data);
            }

            return BadRequest(token);
        }

        [HttpGet("getProfileImage")]
        public IActionResult GetProfileImage([FromQuery] string username)
        {
            var user = _userService.GetByUsername(username);
            if (user == null)
            {
                return BadRequest();
            }
            var path=  Path.Combine(Path.GetPathRoot(Environment.SystemDirectory)!, "ProfileImages");
            var ext = user.PicturePath.Split(".")[1];
            Byte[] b = System.IO.File.ReadAllBytes(path+$"/{user.PicturePath}");  

            return File(b, $"image/{ext}");
        }

    }
}
