using System.ComponentModel.DataAnnotations;

namespace UserManagementMVCExample.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public bool IsSuccessful { get; set; }

        [Required]
        public ApplicationUser Customer { get; set; }

        [Required] 
        public Order Order { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }

        public CreditCardAttribute CreditCard { get; set; }
    }
    public enum PaymentType { Card, Cash}
}