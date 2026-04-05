using Microsoft.AspNetCore.Mvc;
using BlogApi.Models;
using BlogApi.Services;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _service;

        // inject via constructor, never use "new"
        public BlogController(BlogService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            return Ok(await _service.GetBlogs());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(string id)  // string not int
        {
            var blog = await _service.GetBlog(id);
            if (blog == null)
                return NotFound();

            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(Blog blog)
        {
            await _service.CreateBlog(blog);
            return CreatedAtAction(nameof(GetBlog), new { id = blog.Id }, blog); // 201 not 200
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(string id)  // string not int
        {
            var blog = await _service.GetBlog(id);
            if (blog == null)
                return NotFound();  // return 404 if not found

            await _service.DeleteBlog(id);
            return NoContent();
        }
    }
}