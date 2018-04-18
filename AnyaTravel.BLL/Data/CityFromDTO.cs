using System.Collections.Generic;

namespace AnyaTravel.BLL.Data
{
    public class CityFromDTO
    {
        public int Id { get; set; }
        public string City { get; set; }

        public List<TourDTO> Tours { get; set; }
    }
}
