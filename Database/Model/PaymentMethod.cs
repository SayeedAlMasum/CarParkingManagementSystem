//PaymentMethod.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }
        [Required]
        public string PaymentMethodName { get; set; }
        public bool IsActive { get; set; }
    }
}