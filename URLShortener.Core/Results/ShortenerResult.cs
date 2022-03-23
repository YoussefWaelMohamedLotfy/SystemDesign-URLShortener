namespace URLShortener.Core.Results;

public record ShortenerResult
{
    public string ShortUrl { get; set; } = default!;

    public string LongUrl { get; set; } = default!;
}
