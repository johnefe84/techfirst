using BlogTest.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogTest.API.Service
{
	public class CategoryService
	{
        private readonly BlogContext _context;

        public CategoryService(BlogContext context)
		{
            _context = context;
            _context.Database.EnsureCreated();
        }

        public ActionResult<IList<Category>> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
    }
}

