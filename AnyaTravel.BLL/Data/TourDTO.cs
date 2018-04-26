using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnyaTravel.BLL.Data
{
    public class TourDTO
    {
        public int Id { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int CountOfTours { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public TourTypeDTO TourType { get; set; }
        public FoodTypeDTO FoodType { get; set; }

        public HotelDTO Hotel { get; set; }
        public TransportTypeDTO TransportType { get; set; }

        public CityFromDTO CityFrom { get; set; }
        public List<OrderDTO> Orders { get; set; }
    }
}
