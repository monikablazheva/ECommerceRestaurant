using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserManagementMVCExample.Models.ViewModels;

namespace UserManagementMVCExample.Models
{
    public class Sushi : Product
    {
        [Range(1, 100, ErrorMessage = "Count must be between 1 and 100.")]
        public int Count { get; set; }

        [Required]
        public SushiType Type { get; set; }
        public ICollection<SushiAssignmentViewModel> SushiAssignments { get; set; }
    }
    public enum SushiType { Uramaki, Maki, Sashimi, Nigiri, Temaki }

}

