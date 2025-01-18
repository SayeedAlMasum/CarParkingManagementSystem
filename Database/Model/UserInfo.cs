//UserInfo.cs
using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class UserInfo : BaseModel
    {
        [Key]
        public string UserInfoId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? PasswordHash { get; set; }

        public string? Location { get; set; }

        public bool IsActive { get; set; } = true;

        public int RoleId { get; set; }
    }
}
