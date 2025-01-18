using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model
{
    public class Subscription
    {
        [Key]
        public string SubscriptionId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string? UserInfoId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public string? SubscriptionType { get; set; }
        [Required]
        public int PaymentId { get; set; }

    }
}
