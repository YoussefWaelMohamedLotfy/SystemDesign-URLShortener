using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SystemDesign_URLShortener.Data;
using URLShortener.Core.Commands;
using URLShortener.Core.Entities;
using URLShortener.Core.Results;

namespace SystemDesign_URLShortener.Endpoints.V1.URLs;

public class Shorten : EndpointBaseSync.WithRequest<ShortenerCommand>.WithActionResult<ShortenerResult>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public Shorten(AppDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost("/api/shorten")]
    public override ActionResult<ShortenerResult> Handle(ShortenerCommand request)
    {
        var url = _mapper.Map<URL>(request);

        url.ShortUrl = "shorty";
        _context.URLs.Add(url);
        _context.SaveChanges();

        var result = _mapper.Map<ShortenerResult>(url);
        return Ok(result);
    }
}
