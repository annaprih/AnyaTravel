using System.Collections.Generic;

namespace AnyaTravel.BLL.Data
{
    public class HotelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }

        public  CityDTO City { get; set; }
        public  PlacementTypeDTO PlacementType { get; set; }
        public  List<TourDTO> Tours { get; set; }

    }
}
