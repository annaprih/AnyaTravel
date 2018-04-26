using AnyaTravel.BLL.Data;
using System.Collections.Generic;

namespace AnyaTravel.API.ViewModels
{
    public class TourView
    {
        public IEnumerable<TourTypeDTO> TourTypes { get; set; }
        public IEnumerable<FoodTypeDTO> FoodTypes { get; set; }
        public IEnumerable<HotelDTO> Hotels { get; set; }
        public IEnumerable<CountryDTO> Countries { get; set; }
        public IEnumerable<CityDTO> Cities { get; set; }
        public IEnumerable<TransportTypeDTO> TransportTypes { get; set; }
        public IEnumerable<PlacementTypeDTO> PlacementTypes { get; set; }

        public IEnumerable<CityFromDTO> CitiesFrom { get; set; }
    }
}
