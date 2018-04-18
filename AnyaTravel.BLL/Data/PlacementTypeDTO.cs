using System.Collections.Generic;

namespace AnyaTravel.BLL.Data
{
    public class PlacementTypeDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public  List<HotelDTO> Hotels { get; set; }
    }

}
