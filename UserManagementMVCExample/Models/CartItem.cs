using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementMVCExample.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CartId { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Price must be between 1 and 1000.")]
        public int Count { get; set; }

        [Required]
        public System.DateTime DateCreated { get; set; }

        [Required]
        public Product Product { get; set; }
        public decimal SubTotal()
        {
            return Product.Price * Count;
        }
    }
}
