using Swashbuckle.AspNetCore.Filters;
using URLShortener.Core.Results;

namespace SystemDesign_URLShortener.Swagger.Examples.Responses;

public class ShortenerResultExample : IExamplesProvider<ShortenerResult>
{
    public ShortenerResult GetExamples()
    {
        return new ShortenerResult { ShortUrl = "5a62509", LongUrl = "https://en.wikipedia.org/wiki/Systems_design" };
    }
}
