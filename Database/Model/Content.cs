using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string?  Type { get; set; }
        [Required]
        public string? URL { get; set; }
        [Required]
        public int SlotId { get; set; }
      
    }
}
