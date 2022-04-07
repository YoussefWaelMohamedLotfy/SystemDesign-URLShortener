using System.ComponentModel.DataAnnotations;

namespace ConsoleClient;

public enum UrlApiEndpoints
{
    [Display(Name = "GET: /api/<ShortUrl>")]
    Redirect,

    [Display(Name = "POST: /api/shorten")]
    MD5Shorten,

    [Display(Name = "POST: /api/shorten/hash")]
    Base62Shorten
}
