using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public int Price { get; set; }

        public TourType TourType { get; set; }
        public FoodType FoodType { get; set; }
        public Hotel Hotel { get; set; }
        public TransportType TransportType { get; set; }
        public Reis Reis { get; set; }

        public  List<Customer> Customers { get; set; }



    }
}
