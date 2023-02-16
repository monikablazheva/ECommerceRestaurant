namespace UserManagementMVCExample.Models.ViewModels
{
    public class ShoppingCartUpdateItemCountViewModel
    {
        public decimal CartTotal { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int UpdatedId { get; set; }
    }
}
