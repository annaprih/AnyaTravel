using System.Collections.Generic;

namespace AnyaTravel.BLL.Data
{
    public class TourTypeDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public  List<TourDTO> Tours { get; set; }
    }
}
