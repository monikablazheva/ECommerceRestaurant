using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserManagementMVCExample.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int SushiProductsCount { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int ApplicationUserID { get; set; }

        [Required]
        public ApplicationUser Customer { get; set; }

        public IEnumerable<Sushi> SushiProducts { get; set; }
    }
}