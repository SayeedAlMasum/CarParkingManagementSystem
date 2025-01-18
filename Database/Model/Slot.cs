using System.ComponentModel.DataAnnotations;

namespace Database.Model
{
    public class Slot : BaseModel
    {
        [Key]
        public int SlotId { get; set; }   // Automatically generating a new GUID

        [Required]
        public string Title { get; set; }  

        [Required]
        public string Description { get; set; } 

        [Required]
        public string Category { get; set; }  

        [Required]
        public bool IsBooked { get; set; }
        [Required]
        public string? SubCategory { get; set; }  
    }
}
