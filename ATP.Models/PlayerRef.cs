using System.ComponentModel.DataAnnotations;

namespace ATP.Models
{
    public class PlayerRef
    {
        [Key]
        public string PlayerId { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
    }
}
