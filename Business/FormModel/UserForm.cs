//UserForm.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FormModel
{
    // Represents the form used for user registration
    public class UserForm
    {
        
        [Required, MaxLength(40)]
        public string? FullName { get; set; }

       
        [Required]
        public string? Email { get; set; }

      
        [Required, MinLength(8)]
        public string? Password { get; set; }

        // Indicates whether the user is active
        public bool IsActive { get; set; }

        // Role ID for the user (defaults to a specific value in the service if not provided)
        public int RoleId { get; set; }
    }
}
