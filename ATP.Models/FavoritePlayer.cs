using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ATP.Models
{
    [Index(nameof(UserId), nameof(PlayerId))]
    public class FavoritePlayer
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public string PlayerId { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public int MyRank { get; set; }
    }
}
