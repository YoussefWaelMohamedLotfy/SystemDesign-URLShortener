using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using URLShortener.Core.Commands;
using URLShortener.Core.Results;

namespace SystemDesign_URLShortener.Endpoints.V1.URLs;

public class Shorten : EndpointBaseSync.WithRequest<ShortenerCommand>.WithActionResult<ShortenerResult>
{


    [HttpPost("/api/shorten")]
    public override ActionResult<ShortenerResult> Handle(ShortenerCommand request)
    {
        return Ok(new ShortenerResult { ID = 5, LongUrl = request.LongUrl, ShortUrl = "Short Version"});
    }
}
