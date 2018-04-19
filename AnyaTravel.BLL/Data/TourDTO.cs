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
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        [Required]
        public TourTypeDTO TourType { get; set; }
        [Required]
        public FoodTypeDTO FoodType { get; set; }
        [Required]
        public HotelDTO Hotel { get; set; }
        [Required]
        public TransportTypeDTO TransportType { get; set; }
        [Required]
        public CityFromDTO CityFrom { get; set; }
        public List<OrderDTO> Orders { get; set; }
    }
}
