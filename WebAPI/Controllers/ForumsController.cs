using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumsController : ControllerBase
    {
        private IForumService _forumService;

        public ForumsController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpGet("getList")]
        public IActionResult GetList()
        {
            var result = _forumService.GetList();
            return Ok(result);
        }
    }
}
