using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnyaTravel.DAL.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FIO { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
