using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public int Status { get; set; }

        public  List<Customer> Customers { get; set; }


    }
}
