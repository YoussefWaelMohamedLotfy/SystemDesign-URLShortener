namespace URLShortener.Core.Commands;

public record ShortenerCommand
{
    public string LongUrl { get; init; } = default!;
}
