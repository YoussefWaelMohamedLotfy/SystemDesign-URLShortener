using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using SystemDesign_URLShortener.Data;

namespace SystemDesign_URLShortener.Endpoints.V1.URLs;

public class Get : EndpointBaseSync.WithRequest<string>.WithActionResult
{
    private readonly AppDbContext _context;

    public Get(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    [HttpGet("/api/{shortUrl}", Name = "Redirecter")]
    public override ActionResult Handle(string shortUrl)
    {
        var urlInDb = _context.URLs.SingleOrDefault(x => x.ShortUrl == shortUrl);

        if (urlInDb is null)
            return NotFound();

        return RedirectPermanent($"{urlInDb.LongUrl}");
    }

    
}
