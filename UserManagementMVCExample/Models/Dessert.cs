using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementMVCExample.Models
{
    public class Dessert : Product
    {
        [Range(1, 3000, ErrorMessage = "Milliliters must be between 1 and 3000.")]
        public int Grams { get; set; }
    }
}
