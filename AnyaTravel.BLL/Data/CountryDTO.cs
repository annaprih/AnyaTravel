using System.Collections.Generic;

namespace AnyaTravel.BLL.Data
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public  List<CityDTO> Cities { get; set; }
    }
}
