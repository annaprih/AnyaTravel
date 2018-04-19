using AnyaTravel.BLL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnyaTravel.API.ViewModels
{
    public class TourView
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int CountOfTours { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public IEnumerable<TourTypeDTO> TourType { get; set; }
        public IEnumerable<FoodTypeDTO> FoodType { get; set; }
        public IEnumerable<HotelDTO> Hotel { get; set; }
        public IEnumerable<TransportTypeDTO> TransportType { get; set; }
        public IEnumerable<CityFromDTO> CityFrom { get; set; }
    }
}
