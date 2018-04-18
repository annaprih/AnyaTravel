using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }
        public  List<Hotel> Hotels { get; set; }

        public  List<Reis> Reises { get; set; }
        
    }
}
