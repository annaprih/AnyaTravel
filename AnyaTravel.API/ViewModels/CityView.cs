using AnyaTravel.BLL.Data;
using System.ComponentModel.DataAnnotations;

namespace AnyaTravel.API.ViewModels
{
    public class CityView
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public CountryDTO Country { get; set; }
    }
}
