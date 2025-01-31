using System.ComponentModel.DataAnnotations;

namespace UserManagementMVCExample.Models
{
    public class OrdersItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Order Order { get; set; }

        [Required]
        public Product Product { get; set; }

        [Range(1, 100000, ErrorMessage = "Price must be between 1 and 100000.")]
        public decimal Price { get; set; }

        [Range(1, 1000, ErrorMessage = "Count must be between 1 and 1000.")]
        public int Count { get; set; }
    }
}
