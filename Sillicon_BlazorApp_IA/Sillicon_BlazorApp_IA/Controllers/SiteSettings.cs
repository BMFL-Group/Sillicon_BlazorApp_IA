using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Sillicon_BlazorApp_IA.Controllers;

public class SiteSettings : Controller
{
    public IActionResult ChangeTheme(string theme)
    {
        try
        {
            var options = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(30),
                SameSite = SameSiteMode.Strict
            };

            //_httpContextAccessor.HttpContext.Response.Cookies.Append("theme", theme, options);
            return Ok(theme);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return StatusCode(500);
    }
}