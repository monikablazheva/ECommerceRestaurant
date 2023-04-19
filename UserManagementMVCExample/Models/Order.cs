using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserManagementMVCExample.Enums;

namespace UserManagementMVCExample.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DeliveryAdress { get; set; }

        [Required]
        public string DeliveryTime { get; set; }

        public DateTime? Date { get; set; }

        public ApplicationUser? Customer { get; set; }

        public bool? IsPaid { get; set; }

        public OrdersStatus OrderStatus { get; set; }

        public decimal Total { get; set; }

        public ICollection<OrdersItem> OrdersItems { get; set; }
    }
}
