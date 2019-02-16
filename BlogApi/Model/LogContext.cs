using BlogApi.Model.Entities.Log;
using Microsoft.EntityFrameworkCore;
using BlogApi.Model.Mappings.Log;

namespace BlogApi.Model
{
    public class LogContext : DbContext
    {
        public DbSet<LogEntry> Logs { get; set; }

        public LogContext(DbContextOptions<LogContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LogMap());
        }
    }
}
