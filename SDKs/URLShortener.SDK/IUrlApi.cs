using Refit;
using URLShortener.Core.Commands;
using URLShortener.Core.Results;

namespace URLShortener.SDK;

public interface IUrlApi
{
    [Get("/api/{shortUrl}")]
    Task RedirectURL(string shortUrl);

    [Post("/api/shorten")]
    Task<ApiResponse<ShortenerResult>> Base62Shorten([Body] ShortenerCommand requestBody);

    [Post("/api/shorten/hash")]
    Task<ApiResponse<ShortenerResult>> MD5Shorten([Body] ShortenerCommand requestBody);
}
