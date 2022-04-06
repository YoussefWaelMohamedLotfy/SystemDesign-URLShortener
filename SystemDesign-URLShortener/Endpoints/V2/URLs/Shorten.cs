using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using SystemDesign_URLShortener.Data;
using SystemDesign_URLShortener.Helpers;
using URLShortener.Core.Commands;
using URLShortener.Core.Entities;
using URLShortener.Core.Results;

namespace SystemDesign_URLShortener.Endpoints.V2.URLs;

public class Shorten : EndpointBaseAsync.WithRequest<ShortenerCommand>.WithActionResult<ShortenerResult>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public Shorten(AppDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Shortens URLs using MD5 Hashing
    /// </summary>
    /// <remarks>
    /// ## Characterisitcs of Hashing + Collision Resolution
    ///   + Fixed short URL length.
    ///   + It does not need a unique ID generator.
    ///   + Collision is possible and must be resolved.
    ///   + It is impossible to figure out the next available short URL
    ///     because it does not depend on ID.
    /// </remarks>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Shortening Success</response>
    [HttpPost("/api/shorten/hash")]
    public override async Task<ActionResult<ShortenerResult>> HandleAsync(ShortenerCommand request, CancellationToken cancellationToken = default)
    {
        var url = _mapper.Map<URL>(request);

        using (MD5 md5 = MD5.Create())
        {
            byte[] urlBytes = Encoding.ASCII.GetBytes(request.LongUrl);
            byte[] hashBytes = md5.ComputeHash(urlBytes);
            url.ShortUrl = hashBytes.ToHex(false)[..7];
        }

        await _context.URLs.AddAsync(url, cancellationToken: cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var result = _mapper.Map<ShortenerResult>(url);
        return Ok(result);
    }
}
