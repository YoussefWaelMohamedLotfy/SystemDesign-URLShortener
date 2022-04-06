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

    /// <summary>
    /// Redirects a shortened URL to its original URL
    /// </summary>
    /// <remarks>
    /// Difference between 301 and 302 redirects.
    /// 
    /// |301 Redirect|302 Redirect|
    /// |------------|------------|
    /// |A 301 redirect shows that the requested URL is “permanently” moved to the long URL.Since it is permanently redirected, the browser caches the response, and subsequent requests for the same URL will not be sent to the URL shortening service. Instead, requests are redirected to the long URL server directly.| A 302 redirect means that the URL is “temporarily” moved to the long URL, meaning that subsequent requests for the same URL will be sent to the URL shortening service first.Then, they are redirected to the long URL server.|
    /// 
    /// Each redirection method has its pros and cons. If the priority is to reduce the server load,
    /// using 301 redirect makes sense as only the first request of the same URL is sent to URL
    /// shortening servers.However, if analytics is important, 302 redirect is a better choice as it can
    /// track click rate and source of the click more easily.
    /// </remarks>
    /// <param name="shortUrl">The Shortened URL</param>
    /// <param name="cancellationToken"></param>
    /// <response code="301">PermenentRedirection</response>
    [HttpGet("/api/{shortUrl}")]
    public override async Task<ActionResult> HandleAsync(string shortUrl, CancellationToken cancellationToken = default)
    {
        var urlInDb = await _context.URLs.SingleOrDefaultAsync(x => x.ShortUrl == shortUrl, cancellationToken: cancellationToken);

        if (urlInDb is null)
            return NotFound("The short URL is not registered. Check again your URL.");

        return RedirectPermanent(urlInDb.LongUrl);
    }
}
