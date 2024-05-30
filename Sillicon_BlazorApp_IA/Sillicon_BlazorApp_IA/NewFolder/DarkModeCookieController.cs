using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System;

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

            //Uri uri = new Uri(currentUrlPath);
            //string baseUrl = uri.GetLeftPart(UriPartial.Query);

            //Uri uri = new Uri(currentUrlPath);

            //string returnUrl = uri.Query; 

  
            //var queryParams = HttpUtility.ParseQueryString(uri.Query);
            //string returnUrlValue = queryParams["ReturnUrl"]!;

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
            //Uri uri = new Uri(currentUrlPath);
            //string baseUrl = uri.GetLeftPart(UriPartial.Query);

            currentUrlPath = HttpContext.Request.GetDisplayUrl();

            string newString = currentUrlPath.Substring(currentUrlPath.LastIndexOf("=") + 1);
            //Uri uri = new Uri(currentUrlPath);

            //string returnUrl = uri.Query;


            //var queryParams = HttpUtility.ParseQueryString(uri.Query);
            //string returnUrlValue = queryParams["ReturnUrl"]!;


            Response.Cookies.Delete("darkmode");
            return Redirect(newString);
        }
    }
}
