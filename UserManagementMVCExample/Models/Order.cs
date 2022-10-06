using System.ComponentModel.DataAnnotations;

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
        
        [Required]
        public Payment Payment { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}
