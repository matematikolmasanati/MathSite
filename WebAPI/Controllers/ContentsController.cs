using Microsoft.AspNetCore.Mvc;
using System;
using Business.Abstract;
using Entities.Concrete;
using static Core.Utilities.Helpers.StringHelper;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        private IContentService _contentService;

        public ContentsController(IContentService contentService)
        {
            _contentService = contentService;
        }



        [HttpPost("add")]
        public IActionResult Add(Content content)
        {
            content.Slug = TitleToSlug(content.Title);
            content.CreatedAt = DateTime.Now;
            var result = _contentService.Add(content);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Content content)
        {
            content.Slug = TitleToSlug(content.Title);
            var result = _contentService.Update(content);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);

        }

        [HttpDelete("delete")]
        public IActionResult Delete(Content content)
        {
            var result = _contentService.Delete(content);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _contentService.GetList(null,null,0,10,true);
            
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getdetail")]
        public IActionResult GetContentDetails([FromQuery] int index=0, [FromQuery] int size=10, [FromQuery] bool enableTracking=true)
        {
            var result=_contentService.GetContentDetails(null,null, index, size, enableTracking);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }


    }
}
