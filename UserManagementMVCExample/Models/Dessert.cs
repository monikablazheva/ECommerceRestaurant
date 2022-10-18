using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Range(1, 3000, ErrorMessage = "Milliliters must be between 1 and 3000.")]
        public int Grams { get; set; }

        [Range(0, 1000, ErrorMessage = "Price must be between 0 and 1000.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public ICollection<Cart> Carts { get; set; }
    }
}
