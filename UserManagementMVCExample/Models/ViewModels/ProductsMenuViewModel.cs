using System.Collections.Generic;

namespace UserManagementMVCExample.Models.ViewModels
{
    public class ProductsMenuViewModel
    {
        public List<Sushi> Sushis { get; set; }
        public List<Combo> Combos { get; set; }
        public List<Beverage> Beverages { get; set; }
        public List<Dessert> Desserts { get; set; }
    }
}
