using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using System.Linq;

namespace Sillicon_BlazorApp_IA.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SiteSettingsController : Controller
{
    //private readonly ISignalRServerBuilder _signalRBuilder;

    //public SiteSettingsController(ISignalRServerBuilder signalRBuilder)
    //{
    //    _signalRBuilder = signalRBuilder;
    //}

    //private readonly HttpContext _httpContext;

    //public SiteSettingsController(HttpContext httpContext)
    //{
    //    _httpContext = httpContext;
    //}

    public const string StatusCookieName = "Theme";

    private static readonly CookieBuilder ThemeCookieBuilder = new()
    {
        MaxAge = TimeSpan.FromDays(30),
        SameSite = SameSiteMode.None,
        IsEssential = true,
        HttpOnly = true,
        SecurePolicy = CookieSecurePolicy.Always,
        Path = "/"
    };

    [HttpGet("{theme}")]
    public async Task<IActionResult> ChangeTheme(string theme)
    {
        try
        {
            Response.Cookies.Append(StatusCookieName, theme, ThemeCookieBuilder.Build(HttpContext));
            if (Response.Headers.SetCookie.Any())
            {
                return new OkObjectResult(theme);
            }
            return new BadRequestObjectResult(theme);


            //var options = new CookieOptions
            //{
            //    Expires = DateTimeOffset.UtcNow.AddDays(30),
            //    SameSite = SameSiteMode.Lax,
            //    HttpOnly = true,
            //    Secure = true,
            //    Path = "/"
            //};


            //Response.Cookies.Append("theme", theme, options);

            //var setCookieValue = new StringValues();

            //var certificate = HttpContext.Connection.GetClientCertificateAsync;
            //var hasSetCookieHeader = HttpContext.Response.Headers.ContainsKey("Set-Cookie");
            //if (hasSetCookieHeader)
            //{
            //    setCookieValue = HttpContext.Response.Headers["Set-Cookie"];
            //    // Now you can work with the value of the Set-Cookie header
            //}

            //return Ok(theme);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return StatusCode(500);
    }
    
}