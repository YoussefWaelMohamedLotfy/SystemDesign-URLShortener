using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace SystemDesign_URLShortener.Endpoints.V1.URLs;

public class Get : EndpointBaseSync.WithRequest<string>.WithActionResult
{



    [HttpGet("/api/{shortUrl}", Name = "Redirecter")]
    public override ActionResult Handle(string shortUrl)
    {
        return Redirect("https://google.com");
    }

    
}
