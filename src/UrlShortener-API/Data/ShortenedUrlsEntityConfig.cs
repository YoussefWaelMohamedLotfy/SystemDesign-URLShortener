using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UrlShortener_API.Data;

internal sealed class ShortenedUrlsEntityConfig : IEntityTypeConfiguration<ShortenedUrl>
{
    public void Configure(EntityTypeBuilder<ShortenedUrl> builder)
    {
        builder.Property(x => x.Code).HasMaxLength(7);
        builder.HasIndex(x => x.Code).IsUnique();
    }
}
