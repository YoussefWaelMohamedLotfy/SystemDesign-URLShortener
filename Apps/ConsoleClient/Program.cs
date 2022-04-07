using ConsoleClient;
using Refit;
using Sharprompt;
using URLShortener.Core.Commands;
using URLShortener.SDK;

var urlApi = RestService.For<IUrlApi>("https://localhost:7261");

string url = string.Empty;

while (true)
{
    var selection = Prompt.Select<UrlApiEndpoints>("Select the endpoint to call");

    try
    {
        switch (selection)
        {
            case UrlApiEndpoints.Redirect:
                url = Prompt.Input<string>("Enter the Short URL");
                await urlApi.RedirectURL(url);
                Console.WriteLine("Redirect Success");
                break;

            case UrlApiEndpoints.MD5Shorten:
               await MD5Shortening(urlApi);
                break;

            case UrlApiEndpoints.Base62Shorten:
                await Base62Shortening(urlApi);
                break;
        }
    }
    catch (ApiException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

async Task MD5Shortening(IUrlApi api)
{
    url = Prompt.Input<string>("Enter the URL to be shortened");
    var MD5Response = await api.MD5Shorten(new ShortenerCommand { LongUrl = url });

    if (MD5Response.IsSuccessStatusCode)
        Console.WriteLine($"Success: {MD5Response.Content}");
    else
        Console.WriteLine($"Error: {MD5Response.Error.Message}");
}

async Task Base62Shortening(IUrlApi api)
{
    url = Prompt.Input<string>("Enter the URL to be shortened");
    var response = await api.Base62Shorten(new ShortenerCommand { LongUrl = url });

    if (response.IsSuccessStatusCode)
        Console.WriteLine($"Success: {response.Content}");
    else
        Console.WriteLine($"Error: {response.Error.Message}");
}