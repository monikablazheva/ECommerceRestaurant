using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserManagementMVCExample.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int SushiProductsCount { get; set; }

        [Range(0, 1000000, ErrorMessage = "Price must be between {0} and {1}.")]
        public decimal Price { get; set; }

        [Range(0, 1000000, ErrorMessage = "Total price must be between {0} and {1}.")]
        public decimal Total { get; set; }
        public int ApplicationUserID { get; set; }

        [Required]
        public ApplicationUser Customer { get; set; }

        public Order Order { get; set; }

        public IEnumerable<Sushi> Sushis { get; set; }
        public IEnumerable<Beverage> Beverages { get; set; }
        public IEnumerable<Dessert> Desserts { get; set; }
    }
}