using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserManagementMVCExample.Models
{
    public class Combo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }

        [Required]
        public IEnumerable<Sushi> Sushis { get; set; }

    }
}
