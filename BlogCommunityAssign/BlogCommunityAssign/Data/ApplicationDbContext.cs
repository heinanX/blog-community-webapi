using BlogCommunityAssign.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogCommunityAssign.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            // Seed Data
            modelBuilder.Entity<Category>().HasData(
                new Category {Id = 1, CategoryName = "adventure" },
                new Category {Id = 2, CategoryName = "iykyk" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Email = "imtehboss@yahoo.com", IsAdmin = true, Password = "admin" },
                new User { Id = 2, Username = "test", Email = "imtehtest@yahoo.com", IsAdmin = false, Password = "test" },
                new User { Id = 3, Username = "dummy", Email = "imtehdummy@yahoo.com", IsAdmin = false, Password = "dummy" }
                );


            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "Test Title", Content = "This is the first blog post", CreatedAt = new DateTime(2026, 1, 10), UpdatedAt = new DateTime(2026, 1, 10), UserId = 2 }
                );

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Posts)
                .UsingEntity(j => j.HasData(
                new { PostsId = 1, CategoriesId = 1, }
                ));


            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = 1, Content = "This is just a dummy comment", UserId = 3, CreatedAt = new DateTime(2026, 1, 10), UpdatedAt = new DateTime(2026, 1, 10), PostId = 1}
                );

        }
    }
}
