using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementMVCExample.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DeliveryAdress { get; set; }
        public bool IsPaid { get; set; }
        public int? ApplicationUserID { get; set; } 

        [ForeignKey("Payment")] 
        public int PaymentID { get; set; }
        
        [Required]
        public Payment Payment { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}
