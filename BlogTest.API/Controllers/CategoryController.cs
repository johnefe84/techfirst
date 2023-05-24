using BlogTest.API.Models;
using BlogTest.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace BlogTest.API.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BlogContext _context;
        private CategoryService categoryService;
        public CategoryController(BlogContext context)
		{
            _context = context;
            _context.Database.EnsureCreated();
            categoryService = new CategoryService(context);
        }

        [HttpGet]
        public ActionResult<List<Category>> GetAllCategories()
        {
            return Ok(categoryService.GetAllCategories());
        }
    }
}

