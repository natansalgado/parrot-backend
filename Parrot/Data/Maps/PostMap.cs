using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parrot.Model;

namespace Parrot.Data.Maps
{
    public class PostMap : IEntityTypeConfiguration<PostModel>
    {
        public void Configure(EntityTypeBuilder<PostModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.PublishedDate).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.UserId).IsRequired();

            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        }
    }
}
