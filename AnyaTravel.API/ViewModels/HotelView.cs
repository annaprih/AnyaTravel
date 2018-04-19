using AnyaTravel.BLL.Data;
using System.ComponentModel.DataAnnotations;

namespace AnyaTravel.API.ViewModels
{
    public class HotelView
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Stars { get; set; }
        [Required]
        public CityDTO City { get; set; }
        [Required]
        public PlacementTypeDTO PlacementType { get; set; }
    }
}
