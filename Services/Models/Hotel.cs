using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }

        public  City City { get; set; }
        public  PlacementType PlacementType { get; set; }
        public  List<Tour> Tours { get; set; }

    }
}
