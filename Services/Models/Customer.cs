using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class Customer
    {
  
        public string Id { get; set; }
        public string Name { get; set; }

        public string Passport { get; set; }

        public DateTime Birthday { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public CustomerStatus CustomerStatus { get; set; }

        public User User { get; set; }
    }
}
