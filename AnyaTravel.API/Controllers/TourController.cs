using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AnyaTravel.API.ViewModels;
using AnyaTravel.BLL.Data;
using AnyaTravel.BLL.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnyaTravel.API.Controllers
{
    [Produces("application/json")]
    public class TourController : Controller
    {
        private readonly ITourService _tourService;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        private readonly IHotelService _hotelService;
        private readonly IFoodTypeService _foodTypeService;
        private readonly ITransportTypeService _transportTypeService;
        private readonly ITourTypeService _tourTypeService;
        private readonly ICityFromService _cityFromService;

        private readonly IMapper _mapper;

        public TourController(ITourService tourService, ICountryService countryService,
            ICityService cityService, IHotelService hotelService,
            IFoodTypeService foodTypeService, ITransportTypeService transportTypeService,
            ITourTypeService tourTypeService, ICityFromService cityFromService,
            IMapper mapper)
        {
            _tourService = tourService;
            _countryService = countryService;
            _cityService = cityService;
            _hotelService = hotelService;
            _foodTypeService = foodTypeService;
            _transportTypeService = transportTypeService;
            _tourTypeService = tourTypeService;
            _cityFromService = cityFromService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/tour")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<TourDTO> tours = await _tourService.Get();
            return Ok(tours);
        }

        [HttpGet]
        [Route("api/tour/getalldatafortour")]
        public async Task<IActionResult> GetAllDataForTour()
        {
            TourView tour = new TourView();
            tour.Hotel = await _hotelService.Get();
            tour.FoodType = await _foodTypeService.Get();
            tour.TourType = await _tourTypeService.Get();
            tour.TransportType = await _transportTypeService.Get();
            tour.CityFrom = await _cityFromService.Get();
            return Ok(tour);
        }


        [HttpGet]
        [Route("api/tour/{id}")]
        public async Task<IActionResult> Get([Required]int id)
        {
            if (ModelState.IsValid)
            {
                TourDTO tour = await _tourService.Get(id);
                if (tour != null)
                {
                    return Ok(tour);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("api/tour")]
        public async Task<IActionResult> Add([FromBody]TourDTO tour)
        {
            if (ModelState.IsValid)
            {
                tour = await _tourService.Add(tour);
                return Ok(tour);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("api/tour")]
        public async Task<IActionResult> Update([FromBody]TourDTO tourView)
        {
            if (ModelState.IsValid)
            {
                TourDTO tour = await _tourService.Get(tourView.Id);
                if (tour != null)
                {
                    tour = _mapper.Map<TourDTO, TourDTO>(tourView);
                    tour = await _tourService.Update(tour);
                    return Ok(tour);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("api/tour/{id}")]
        public async Task<IActionResult> Delete([Required]int id)
        {
            if (ModelState.IsValid)
            {
                TourDTO tour = await _tourService.Get(id);
                if (tour != null)
                {
                    tour = await _tourService.Delete(tour);
                    return Ok(tour);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("api/tour/addcountry")]
        public async Task<IActionResult> AddCountry([FromBody]CountryDTO country)
        {
            if (ModelState.IsValid)
            {
                country = await _countryService.Add(country);
                return Ok(country);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("api/tour/addcity")]
        public async Task<IActionResult> AddCity([FromBody]CityDTO city)
        {
            if (ModelState.IsValid)
            {
                city = await _cityService.Add(city);
                return Ok(city);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("api/tour/addhotel")]
        public async Task<IActionResult> AddHotel([FromBody]HotelDTO hotel)
        {
            if (ModelState.IsValid)
            {
                hotel = await _hotelService.Add(hotel);
                return Ok(hotel);
            }
            return BadRequest(ModelState);
        }
    }
}


