using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    //1. add model 
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
      
        public string? ImagePath { get; set; }
        [NotMapped]
        public IFormFile ClientFile { get; set; }
    }
}
