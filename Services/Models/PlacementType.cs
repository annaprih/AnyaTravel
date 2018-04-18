using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class PlacementType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public  List<Hotel> Hotels { get; set; }

    }

}
