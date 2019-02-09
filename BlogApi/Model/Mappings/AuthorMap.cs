using BlogApi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApi.Model.Mappings
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Firstname).HasColumnName("Firstname");
            builder.Property(x => x.Lastname).HasColumnName("Lastname");
            builder.Property(x => x.EMail).HasColumnName("EMail");
            builder.Property(x => x.Birth).HasColumnName("Birth");

            builder.HasMany(x => x.Blogentrys);
        }
    }
}
