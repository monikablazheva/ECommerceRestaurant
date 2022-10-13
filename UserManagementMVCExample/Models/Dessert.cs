using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserManagementMVCExample.Models
{
    public class Dessert
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, 3000, ErrorMessage = "Milliliters must be between {0} and {1}.")]
        public int Grams { get; set; }

        [Range(0, 1000, ErrorMessage = "Price must be between {0} and {1}.")]
        public decimal Price { get; set; }

        public IEnumerable<Cart> Carts { get; set; }
    }
}
