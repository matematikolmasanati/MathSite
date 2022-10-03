using System.Security.Claims;
using Business.Abstract;
using Core.Extensions;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscussionsController : ControllerBase
    {
        private IDiscussionService _discussionService;

        public DiscussionsController(IDiscussionService discussionService)
        {
            _discussionService = discussionService;
        }

        [HttpGet("detailForList")]
        public IActionResult GetDetailsForList([FromQuery] int index = 0, [FromQuery] int size = 10)
        {
            var result = _discussionService.GetDetailForList(null, null,index, size);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Discussion discussion)
        {
           var result = _discussionService.Add(discussion);
            
            return Ok(result);
        }

        [HttpGet("getBySlug")]
        public IActionResult GetBySlug(string slug)
        {
            var result = _discussionService.GetBySlug(slug);
            return Ok(result);
        }
    }
}
