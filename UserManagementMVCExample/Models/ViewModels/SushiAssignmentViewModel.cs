using System.ComponentModel.DataAnnotations;

namespace UserManagementMVCExample.Models.ViewModels
{
    public class SushiAssignmentViewModel
    {
        public int ComboID { get; set; }
        public int SushiID { get; set; }
        public Combo Combo { get; set; }
        public Sushi Sushi { get; set; }
    }
}
