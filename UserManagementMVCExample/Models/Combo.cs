using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementMVCExample.Models
{
    public class Combo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, 1000, ErrorMessage = "Price must be between 0 and 1000.")]
        public int Count { get; set; }

        [Range(0, 1000, ErrorMessage = "Price must be between 0 and 1000.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public ICollection<Sushi> Sushis { get; set; }

    }
}
