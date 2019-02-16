using BlogApi.Model.Entities.Log;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApi.Model.Mappings.Log
{
    public class LogMap : IEntityTypeConfiguration<LogEntry>
    {
        public void Configure(EntityTypeBuilder<LogEntry> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Location).HasColumnName("Location");
            builder.Property(x => x.LogTime).HasColumnName("LogTime");
            builder.Property(x => x.ErrorType).HasColumnName("ErrorType");
            builder.Property(x => x.ErrorMessage).HasColumnName("ErrorMessage");
            builder.Property(x => x.StackTrace).HasColumnName("StackTrace");
        }
    }
}
