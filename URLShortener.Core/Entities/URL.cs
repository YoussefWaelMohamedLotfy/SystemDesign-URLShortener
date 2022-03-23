namespace URLShortener.Core.Entities;

public class URL
{
    public int ID { get; set; }

    public string ShortUrl { get; set; } = default!;

    public string LongUrl { get; set; } = default!;
}
