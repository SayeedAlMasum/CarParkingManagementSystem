//LogIn.cshtml.cs
using System.Security.Claims;
using Business;
using Business.FormModel;
using Business.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public UserLogInForm userLogInForm { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Result result = new UserInfoService().LogIn(userLogInForm);
            if (result.Success)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userLogInForm.Email ?? string.Empty),
            new Claim(ClaimTypes.Role, result.Data?.ToString() ?? "Student") // Default role
        };

                var identity = new ClaimsIdentity(claims, "login");
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(principal);

                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return Page();
            }
        }

    }
}