using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace SystemDesign_URLShortener.Endpoints.V1.URLs;

public class Shorten : EndpointBaseSync.WithRequest<string>.WithActionResult
{


    [HttpPost("/api/shorten")]
    public override ActionResult Handle(string longUrl)
    {
        return Ok(new { longUrl = longUrl });
    }
}
