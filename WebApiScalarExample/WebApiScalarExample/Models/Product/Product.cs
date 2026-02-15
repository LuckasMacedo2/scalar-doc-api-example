using System.ComponentModel.DataAnnotations;

namespace WebApiScalarExample.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The value must be greather than 0")]
        public double Price { get; set; }
    }
}
