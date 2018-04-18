using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class Reis
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int Number { get; set; }
         
        public  City CityFrom { get; set; }
        public  City CityTo { get; set; }

        public  List<Tour> Tours { get; set; }


    }
}
