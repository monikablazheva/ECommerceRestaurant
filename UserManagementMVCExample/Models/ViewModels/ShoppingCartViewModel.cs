﻿using System.Collections.Generic;

namespace UserManagementMVCExample.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal CartTotal { get; set; }
        public ApplicationUser User { get; set; }
    }
}
