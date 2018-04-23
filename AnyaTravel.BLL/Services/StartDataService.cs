using AnyaTravel.BLL.Interfaces;
using AnyaTravel.DAL.Interfaces;
using AnyaTravel.DAL.Models;
using System;
using System.Threading.Tasks;

namespace AnyaTravel.BLL.Services
{
    public class StartDataService : IStartDataService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IFoodTypeRepository _foodTypeRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICityFromRepository _cityFromRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IPlacementTypeRepository _placementTypeRepository;
        private readonly ITransportTypeRepository _transportTypeRepository;
        private readonly ITourTypeRepository _tourTypeRepository;

        public StartDataService(IFoodTypeRepository foodTypeRepository, ICityRepository cityRepository,
             ICountryRepository countryRepository, IHotelRepository hotelRepository,
             IPlacementTypeRepository placementTypeRepository, ITransportTypeRepository transportTypeRepository,
             ITourTypeRepository tourTypeRepository, ICityFromRepository cityFromRepository,
             ITourRepository tourRepository)

        {
            _tourRepository = tourRepository;
            _foodTypeRepository = foodTypeRepository;
            _cityRepository = cityRepository;
            _cityFromRepository = cityFromRepository;
            _countryRepository = countryRepository;
            _hotelRepository = hotelRepository;
            _placementTypeRepository = placementTypeRepository;
            _transportTypeRepository = transportTypeRepository;
            _tourTypeRepository = tourTypeRepository;
        }


        async Task IStartDataService.AddCities()
        {
            City city = new City();
            city.Name = "Хургада";
            city.Country = await _countryRepository.Get(1);
            await _cityRepository.Add(city);
        }

        async Task IStartDataService.AddCitiesFrom()
        {
            await _cityFromRepository.Add(new CityFrom { City = "Минск" });
            await _cityFromRepository.Add(new CityFrom { City = "Москва" });
            await _cityFromRepository.Add(new CityFrom { City = "Киев" });
        }

        async Task IStartDataService.AddCountries()
        {
            await _countryRepository.Add(new Country { Name = "Египет" });
        }

        async Task IStartDataService.AddData()
        {
            await ((IStartDataService)this).AddTypeOfTours();
            await ((IStartDataService)this).AddTypeOfPlacement();
            await ((IStartDataService)this).AddTypeOfTransport();
            await ((IStartDataService)this).AddTypeOfFood();
            await ((IStartDataService)this).AddCountries();
            await ((IStartDataService)this).AddCities();
            await ((IStartDataService)this).AddHotels();
            await ((IStartDataService)this).AddCitiesFrom();
            await ((IStartDataService)this).AddTour();
        }

        async Task IStartDataService.AddHotels()
        {
            PlacementType placement = await _placementTypeRepository.Get(1);
            City city = await _cityRepository.Get(1);
            await _hotelRepository.Add(new Hotel
            {
                Name = "КоралРиф",
                Stars = 5,
                PlacementType = placement,
                City = city
            });
        }

        async Task IStartDataService.AddTour()
        {
            Tour tour = new Tour();
            tour.FoodType = await _foodTypeRepository.Get(1);
            tour.TransportType = await _transportTypeRepository.Get(1);
            tour.TourType = await _tourTypeRepository.Get(1);
            tour.CityFrom = await _cityFromRepository.Get(1);
            tour.Hotel = await _hotelRepository.Get(1);
            tour.CountOfTours = 3;
            tour.DateFrom = new DateTime(2018, 5, 5);
            tour.DateTo = new DateTime(2018, 5, 15);
            tour.Price = 400;
            await _tourRepository.Add(tour);
        }

        async Task IStartDataService.AddTypeOfFood()
        {
            await _foodTypeRepository.Add(new FoodType { Type = "Все включено" });
            await _foodTypeRepository.Add(new FoodType { Type = "Только завтраки" });
            await _foodTypeRepository.Add(new FoodType { Type = "Только ужины" });
            await _foodTypeRepository.Add(new FoodType { Type = "Завтраки и ужины" });
            await _foodTypeRepository.Add(new FoodType { Type = "Без питания" });
        }

        async Task IStartDataService.AddTypeOfPlacement()
        {
            await _placementTypeRepository.Add(new PlacementType { Type = "Двухместный" });
            await _placementTypeRepository.Add(new PlacementType { Type = "Однометсный" });
            await _placementTypeRepository.Add(new PlacementType { Type = "Трехместный" });
            await _placementTypeRepository.Add(new PlacementType { Type = "Семейный" });
            await _placementTypeRepository.Add(new PlacementType { Type = "Люкс" });
        }

        async Task IStartDataService.AddTypeOfTours()
        {
            await _tourTypeRepository.Add(new TourType { Type = "Экскурсионный" });
            await _tourTypeRepository.Add(new TourType { Type = "Лечение" });
            await _tourTypeRepository.Add(new TourType { Type = "Пляжный" });
            await _tourTypeRepository.Add(new TourType { Type = "Шоппинг" });
            await _tourTypeRepository.Add(new TourType { Type = "Горнолыжный" });
            await _tourTypeRepository.Add(new TourType { Type = "Горящий" });
        }

        async Task IStartDataService.AddTypeOfTransport()
        {
            await _transportTypeRepository.Add(new TransportType { Type = "Самолет" });
            await _transportTypeRepository.Add(new TransportType { Type = "Поезд" });
            await _transportTypeRepository.Add(new TransportType { Type = "Автобус" });
            await _transportTypeRepository.Add(new TransportType { Type = "Корабль" });
        }
    }
}
