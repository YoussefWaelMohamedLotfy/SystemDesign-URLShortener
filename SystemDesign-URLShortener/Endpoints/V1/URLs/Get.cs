using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemDesign_URLShortener.Data;

namespace SystemDesign_URLShortener.Endpoints.V1.URLs;

public class Get : EndpointBaseAsync.WithRequest<string>.WithActionResult
{
    private readonly AppDbContext _context;

    public Get(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    [HttpGet("/api/{shortUrl}", Name = "Redirecter")]
    public override async Task<ActionResult> HandleAsync(string shortUrl, CancellationToken cancellationToken = default)
    {
        var urlInDb = await _context.URLs.SingleOrDefaultAsync(x => x.ShortUrl == shortUrl, cancellationToken: cancellationToken);

        if (urlInDb is null)
            return NotFound();

        return RedirectPermanent($"{urlInDb.LongUrl}");
    }
}
