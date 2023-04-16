using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KostRentApp.Models
{
    public class DataKost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? Price { get; set; }
        public string? Photo { get; set; }
        public string? Status { get; set; }






    }
}
