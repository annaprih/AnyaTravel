using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class FoodType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public  List<Tour> Tours { get; set; }

    }
}

