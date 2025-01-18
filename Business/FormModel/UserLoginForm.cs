//UserLogIn.cs
using System.ComponentModel.DataAnnotations;

namespace Business.FormModel
{
    // Represents the form used for user login
    public class UserLoginForm
    {
       
        [Required]
        public string? Email { get; set; }

        [Required, MinLength(8)]
        public string? Password { get; set; }
    }
}
