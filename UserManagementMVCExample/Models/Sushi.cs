using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementMVCExample.Models
{
    public class Sushi
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, 100, ErrorMessage = "Count must be between 1 and 100.")]
        public int Count { get; set; }

        [Required]
        public SushiType Type { get; set; }

        [Range(0, 1000, ErrorMessage = "Price must be between 0 and 1000.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public byte[] ImageURL { get; set; }

        public ICollection<Cart> Carts { get; set; }

        public ICollection<Combo> Combos { get; set; }
        public ICollection<SushiAssignmentViewModel> SushiAssignments { get; set; }
    }
    public enum SushiType { Uramaki, Maki, Sashimi, Nigiri, Temaki }

}

