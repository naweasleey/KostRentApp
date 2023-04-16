using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KostRentApp.Models
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Username must be 3 - 12 characters")]

        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
