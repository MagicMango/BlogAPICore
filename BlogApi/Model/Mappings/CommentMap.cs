using BlogApi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Model.Mappings
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.BlogId).HasColumnName("BlogId");
            builder.Property(x => x.InsertDate).HasColumnName("InsertDate");
            builder.Property(x => x.Subject).HasColumnName("Subject");
            builder.Property(x => x.Entry).HasColumnName("Entry");

            builder.HasOne(x => x.Blog);
        }
    }
}
