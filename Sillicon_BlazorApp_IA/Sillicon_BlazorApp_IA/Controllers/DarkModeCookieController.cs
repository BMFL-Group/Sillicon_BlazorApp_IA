using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Sillicon_BlazorApp_IA.NewFolder
{
    
    public class DarkModeCookieController : Controller
    {

        [HttpGet ("/darkmode")]
        public IActionResult DarkmodeCookie()
        {
            string currentUrlPath = "";
            currentUrlPath = HttpContext.Request.GetDisplayUrl();
            string newString = currentUrlPath.Substring(currentUrlPath.LastIndexOf("=") + 1);

            CookieOptions co = new()
            {
                Expires = DateTime.Now.AddYears(1),
            };

            Response.Cookies.Append("darkmode","dark", co);
            return Redirect(newString);
        }

        [HttpGet("/deletedarkmode")]
        public IActionResult DeleteDarkmodeCookie()
        {
            string currentUrlPath = "";
            currentUrlPath = HttpContext.Request.GetDisplayUrl();
            string newString = currentUrlPath.Substring(currentUrlPath.LastIndexOf("=") + 1);

            Response.Cookies.Delete("darkmode");
            return Redirect(newString);
        }
    }
}
