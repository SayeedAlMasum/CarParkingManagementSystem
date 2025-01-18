using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model
{
    public class Reviews
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public string? UserInfoId { get; set;}
        [Required]
        public int Rating { get; set;}

        public string? Comments { get; set; }
    }
}
