﻿using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SystemDesign_URLShortener.Data;
using SystemDesign_URLShortener.Helpers;
using URLShortener.Core.Commands;
using URLShortener.Core.Entities;
using URLShortener.Core.Results;

namespace SystemDesign_URLShortener.Endpoints.V1.URLs;

public class Shorten : EndpointBaseAsync.WithRequest<ShortenerCommand>.WithActionResult<ShortenerResult>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public Shorten(AppDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpPost("/api/shorten")]
    public override async Task<ActionResult<ShortenerResult>> HandleAsync(ShortenerCommand request, CancellationToken cancellationToken = default)
    {
        var url = _mapper.Map<URL>(request);
        int maxID = _context.URLs.Select(x => x.ID).Max();
        url.ShortUrl = Base62Converter.EncodeUInt64((ulong)maxID + 1);

        await _context.URLs.AddAsync(url, cancellationToken: cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var result = _mapper.Map<ShortenerResult>(url);
        return Ok(result);
    }
}
