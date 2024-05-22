using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Sillicon_BlazorApp_IA.Controllers;


public class SiteSettings : Controller
{
    [HttpGet("/api/changetheme/{theme}")]
    //[HttpPost]
    public async Task<IActionResult> ChangeTheme(string theme)
    {
        try
        {
            var options = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(30),
                //SameSite = SameSiteMode.Lax,
                Secure = true                
            };            

            Response.Cookies.Append("theme", theme, options);
            return Ok(theme);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return StatusCode(500);
    }
}