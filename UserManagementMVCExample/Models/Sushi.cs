using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Range(1, 100, ErrorMessage = "Count must be between {0} and {1}.")]
        public int Count { get; set; }

        [Required]
        public SushiType Type { get; set; }

        [Range(0, 1000, ErrorMessage = "Price must be between {0} and {1}.")]
        public decimal Price { get; set; }

        public IEnumerable<Cart> Carts { get; set; }

        public IEnumerable<Combo> Combos { get; set; }

        /*private Sushi()
        {

        }
        public Sushi(string name, string description, int count, SushiType type)
        {
            Name = name;
            Description = description;
            Count = count;
            Type = type;
        }*/
    }
    public enum SushiType { Uramaki, Maki, Sashimi, Nigiri, Temaki }

}

