using System.Threading.Tasks;

namespace AnyaTravel.BLL.Interfaces
{
    public interface IStartDataService
    {
        Task AddTypeOfTours();
        Task AddTypeOfFood();
        Task AddTypeOfTransport();
        Task AddTypeOfPlacement();
        Task AddCountries();
        Task AddCities();
        Task AddHotels();
        Task AddCitiesFrom();
        Task AddTour();
        Task AddData();
    }
}
