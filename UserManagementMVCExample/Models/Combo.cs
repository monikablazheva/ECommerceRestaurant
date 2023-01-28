using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserManagementMVCExample.Models.ViewModels;

namespace UserManagementMVCExample.Models
{
    public class Combo : Product
    {
        [Range(0, 1000, ErrorMessage = "Count must be between 0 and 1000.")]
        public int Count { get; set; }
        public ICollection<SushiAssignmentViewModel> SushiAssignments { get; set; }
    }
}
