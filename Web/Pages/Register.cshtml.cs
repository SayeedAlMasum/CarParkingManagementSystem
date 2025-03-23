//Register.cshtml.cs
using Business;
using Business.FormModel;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserRegisterForm userRegisterForm { get; set; } = new UserRegisterForm();

        private readonly UserInfoService _userInfoService;
        public RegisterModel(UserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // Ensure the role is either "Student" or "Teacher"
            if(userRegisterForm.Role!= "Student" && userRegisterForm.Role!= "Teacher" && userRegisterForm.Role!="Admin")
            {
                ModelState.AddModelError("", "Invalid Role Selected.");
                return Page();
            }

            // Register the user with the selected role
            Result result = _userInfoService.Registration(userRegisterForm, userRegisterForm.Role);
            if (result.Success)
            {
                return RedirectToPage("/LogIn");
            }
            else
            {
                ModelState.AddModelError("", result.Message);
                return Page();  
            }
        }
          
    }

}