using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int Price { get; set; }

        public  Customer Customer { get; set; }

        public  Tour Tour { get; set; }

        public  OrderStatus OrderStatus { get; set; }


    }
}
