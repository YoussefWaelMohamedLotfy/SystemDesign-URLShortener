namespace URLShortener.Core.Results;

public record ShortenerResult
{
    public int ID { get; set; }

    public string ShortUrl { get; set; } = default!;

    public string LongUrl { get; set; } = default!;
}
