using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FormModel
{
    public class UserRegisterForm
    {
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } =string.Empty;
        [Required,MinLength(8)]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;


    }
}
