//UserInfo.cs
using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class UserInfo : BaseModel
    {
        [Key]
        [MaxLength(128)]
        public string UserInfoId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? PasswordHash { get; set; }

        [MaxLength(50)]
        public string? Location { get; set; }
        [Required]
        public string Role { get; set; } = "Student";

        public bool IsActive { get; set; } = true;
        public int RoleId { get; set; }
    }
}
