using Azure;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Primitives;
using System.Diagnostics;

namespace Sillicon_BlazorApp_IA.Controllers;


public class SiteSettingsController : Controller
{
    [HttpGet("/api/changetheme/{theme}")]
    //[HttpPost]
    public async Task<IActionResult> ChangeTheme(string theme)
    {
        try
        {
            var options = new CookieOptions
            {
                MaxAge = TimeSpan.FromMinutes(2),
                Expires = DateTimeOffset.UtcNow.AddDays(30),
                SameSite = SameSiteMode.Lax,
                HttpOnly = true,
                Secure = true,
                Path = "/"
            };


            Response.Cookies.Append("theme", theme, options);

            var setCookieValue = new StringValues();

            var certificate = HttpContext.Connection.GetClientCertificateAsync;
            var hasSetCookieHeader = HttpContext.Response.Headers.ContainsKey("Set-Cookie");
            if (hasSetCookieHeader)
            {
                setCookieValue = HttpContext.Response.Headers["Set-Cookie"];
                // Now you can work with the value of the Set-Cookie header
            }

            return Ok(theme);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return StatusCode(500);
    }
}