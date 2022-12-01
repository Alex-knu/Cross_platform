using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;
using Web_cross_platform.Models;

namespace Web_cross_platform.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(OktaDefaults.MvcAuthenticationScheme);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SignOut()
        {
            return new SignOutResult(
                new[]
                {
                    OktaDefaults.MvcAuthenticationScheme,
                    CookieAuthenticationDefaults.AuthenticationScheme,
                },
                new AuthenticationProperties { RedirectUri = "/Home/" });
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View(new UserProfileModel()
            {
                Email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value.ToString(),
                FirstName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "given_name").Value.ToString(),
                LastName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "family_name").Value.ToString(),
                UserName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "preferred_username").Value.ToString(),
                PhoneNumber = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "phone_number")?.Value.ToString()
            });
        }

    }
}
