using System.Linq;
using BlogTest.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogTest.API.Service
{
	public class BlogService
	{

        private readonly BlogContext _context;

        public BlogService(BlogContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public ActionResult<IList<Blog>> GetAllBlogs()
        {
            return _context.Blogs.OrderByDescending(b => b.Timestamp).ToList();
        }

        public Blog? GetBlog(int id)
        {
            var blog = _context.Blogs.Find(id);
            if (blog == null)
            {
                return null;
            }
            return blog;
        }


        public ActionResult<int> PostBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();

            return blog.Id;
        }


        public ActionResult<int> PutBlog(int id, Blog blog)
        {
            _context.Entry(blog).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Blogs.Any(p => p.Id == id))
                {
                    return 0;
                }
                else
                {
                    throw;
                }
            }

            return id;
        }

        public ActionResult<Boolean> DeleteBlog(int id)
        {
            var blog = _context.Blogs.Find(id);
            if (blog == null)
            {
                return false;
            }

            _context.Blogs.Remove(blog);
            _context.SaveChangesAsync();

            return true;
        }


        public ActionResult<Boolean> DeleteAllBlogs()
        {
      
            var blogs = _context.Blogs.ToList();

            if (blogs == null)
            {
                return false;
            }
            
            _context.Blogs.RemoveRange(blogs);
            _context.SaveChangesAsync();

            return true;
        }
    }
}