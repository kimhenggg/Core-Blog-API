using Microsoft.AspNetCore.Mvc;
using BlogApi.Models;
using BlogApi.Services;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _service = new BlogService();

        [HttpGet]
        public IActionResult GetBlog()
        {
            return Ok(_service.GetBlogs());
        }

        [HttpGet("{id}")]
        public IActionResult GetResult(int id)
        {
            var blog = _service.GetBlog(id);
            if (blog == null)
                return NotFound();
            
            return Ok(blog);
        }

        [HttpPost]
        public IActionResult CreateBlog(Blog blog)
        {
            _service.CreateBlog(blog);
            return Ok(blog); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            _service.DeleteBlog(id);
            return NoContent();
        }
    }
}