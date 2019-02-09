using BlogApi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BlogApi.Model.Mappings
{
    public class BlogEntryMap : IEntityTypeConfiguration<BlogEntry>
    {
        public void Configure(EntityTypeBuilder<BlogEntry> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.AuthorId).HasColumnName("AuthorId");
            builder.Property(x => x.Categories).HasColumnName("Categories");
            builder.Property(x => x.Entry).HasColumnName("Entry");
            builder.Property(x => x.InsertDate).HasColumnName("InsertDate");
            builder.Property(x => x.Subject).HasColumnName("Subject");

            builder.HasMany(x => x.Comments);
            builder.HasOne(x => x.Author);
        }
    }
}
