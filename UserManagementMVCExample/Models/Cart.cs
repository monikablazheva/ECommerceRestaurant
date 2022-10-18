using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementMVCExample.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int SushiProductsCount { get; set; }

        [Range(0, 1000000, ErrorMessage = "Price must be between 0 and 1000000.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Range(0, 1000000, ErrorMessage = "Price must be between 0 and 1000000.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }
        public int ApplicationUserID { get; set; }

        [Required]
        public ApplicationUser Customer { get; set; }

        public Order Order { get; set; }

        public ICollection<Sushi> Sushis { get; set; }
        public ICollection<Beverage> Beverages { get; set; }
        public ICollection<Dessert> Desserts { get; set; }
    }
}