using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using URLShortener.Core.Entities;

namespace SystemDesign_URLShortener.Data.EntityConfigurations
{
    public class URLConfiguration : IEntityTypeConfiguration<URL>
    {
        public void Configure(EntityTypeBuilder<URL> builder)
        {
            builder.Property(b => b.ShortUrl).IsRequired();
            builder.Property(b => b.LongUrl).IsRequired();
        }
    }
}
