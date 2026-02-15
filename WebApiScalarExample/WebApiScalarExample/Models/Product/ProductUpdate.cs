using System.ComponentModel.DataAnnotations;

namespace WebApiScalarExample.Models
{
    public class ProductUpdate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The value must be greather than 0")]
        public double Price { get; set; }
    }
}
