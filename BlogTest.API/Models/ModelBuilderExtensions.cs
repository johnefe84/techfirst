using Microsoft.EntityFrameworkCore;

namespace BlogTest.API.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "General" },
                new Category { Id = 2, Name = "Technology" },
                new Category { Id = 3, Name = "Random" });

            modelBuilder.Entity<Blog>().HasData(
                new Blog { Id = 1, CategoryId = 2, Title = "Blog Post Title 1", Contents = "<p>This is a blog post</p>"},
                new Blog { Id = 2, CategoryId = 1, Title = "Blog Post 2 Title", Contents = "<p>This is another blog post</p>"});
        }
    }
}
