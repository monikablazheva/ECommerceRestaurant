using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementMVCExample.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public string CartId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual Product Product { get; set; }

        private decimal _SubTotal;

        [Range(0, 1000000, ErrorMessage = "Price must be between 0 and 1000000.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SubTotal
        {
            get { return _SubTotal; }
            set { _SubTotal = Product.Price * Count; }
        }
    }
}
