using System.Collections.Generic;

namespace AnyaTravel.BLL.Data
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CountryDTO Country { get; set; }
        public List<HotelDTO> Hotels { get; set; }
    }
}
