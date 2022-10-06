﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserManagementMVCExample.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomeAdress { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;
        public byte[] ProfilePicture { get; set; }
        public int? CartID { get; set; }
        public Cart Cart { get; set; }
        public IEnumerable<Order> CompletedOrders { get; set; }

    }
}
