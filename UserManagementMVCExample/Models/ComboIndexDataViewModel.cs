﻿using System.Collections.Generic;

namespace UserManagementMVCExample.Models
{
    public class ComboIndexDataViewModel
    {
        public IEnumerable<Combo> Combos { get; set; }
        public IEnumerable<Sushi> Sushis { get; set; }
    }
}
