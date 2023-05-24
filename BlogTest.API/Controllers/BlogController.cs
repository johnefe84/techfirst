using BlogTest.API.Service;
using BlogTest.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogTest.API.Controllers
{
    [Route("posts")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogContext _context;
        private BlogService blogService;

        public BlogController(BlogContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
            blogService = new BlogService(context);
        }

        [HttpGet]
        public ActionResult<List<Blog>> GetAllBlogs()
        {
            return Ok(blogService.GetAllBlogs());
        }

        [HttpGet("{id}")]
        public ActionResult<Blog> GetBlog(int id)
        {
            return Ok(blogService.GetBlog(id));
        }

        [HttpPost]
        public ActionResult<Blog> PostBlog(Blog blog)
        {
            return CreatedAtAction(
                "GetBlog",
                new { id = blogService.PostBlog(blog)},
                blog);
        }

        [HttpPut("{id}")]
        public ActionResult PutBlog(int id, Blog blog)
        {

            return CreatedAtAction(
                "GetBlog",
                new { id = blogService.PutBlog(id, blog) },
                blog);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBlog(int id)
        {     
            return blogService.DeleteBlog(id).Value ? NoContent() : BadRequest();
        }

        [HttpDelete]
        public ActionResult DeleteAllBlogs()
        {
            return blogService.DeleteAllBlogs().Value ? NoContent() : BadRequest();
        }
    }
}
