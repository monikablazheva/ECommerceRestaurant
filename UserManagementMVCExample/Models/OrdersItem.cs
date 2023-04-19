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

        public decimal Price { get; set; }

        public int Count { get; set; }
    }
}
