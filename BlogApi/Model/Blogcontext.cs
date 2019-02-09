using BlogApi.Model.Entities;
using BlogApi.Model.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Model
{
    public class BlogContext: DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<BlogEntry> BlogEntrys { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=raspbx;database=BlogDB;user=BlogUser;password=u}[kT7Y@[`Dv9Xm4");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AuthorMap());
            modelBuilder.ApplyConfiguration(new BlogEntryMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
        }
    }
}
