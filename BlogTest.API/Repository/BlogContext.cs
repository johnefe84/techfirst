using Microsoft.EntityFrameworkCore;

namespace BlogTest.API.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Blog)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId);

            modelBuilder.Seed();
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
