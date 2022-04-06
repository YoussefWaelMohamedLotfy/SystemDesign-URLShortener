using Swashbuckle.AspNetCore.Filters;
using URLShortener.Core.Commands;

namespace SystemDesign_URLShortener.Swagger.Examples.Requests;

public class ShortenerCommandExample : IExamplesProvider<ShortenerCommand>
{
    public ShortenerCommand GetExamples()
    {
        return new ShortenerCommand { LongUrl = "https://en.wikipedia.org/wiki/Systems_design" };
    }
}
