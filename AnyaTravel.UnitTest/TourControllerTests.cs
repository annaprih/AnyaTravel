using AnyaTravel.API.AutoMapperConfig;
using AnyaTravel.API.Controllers;
using AnyaTravel.BLL.Data;
using AnyaTravel.BLL.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnyaTravel.UnitTest
{
    [TestClass]
    public class TourControllerTests
    {
        [TestMethod]
        public async Task WhenExecuteGetAllThenGetCollection()
        {
            //Arrange
            List<TourDTO> tourDTOs = new List<TourDTO>
            {
                new TourDTO(),
                new TourDTO()
            };
            Mock<ITourService> mock = new Mock<ITourService>();
            mock.Setup(repo => repo.Get()).ReturnsAsync(tourDTOs);

            //Act 
            TourController controller = new TourController(mock.Object, null, null, null, null, null, null, null, null, null);
            IActionResult result = await controller.Get();
            object tours = (result as OkObjectResult)?.Value;

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(tours, typeof(IEnumerable<TourDTO>));
            Assert.IsNotNull(tours as IEnumerable<TourDTO>);
            Assert.AreEqual(tourDTOs, tours);
        }

        [TestMethod]
        public async Task WhenExecuteGetByIdIfElementNotFoundThenGetNotFoundResult()
        {
            TourDTO tour = null;
            Mock<ITourService> mock = new Mock<ITourService>();
            mock.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(tour);

            TourController controller = new TourController(mock.Object, null, null, null, null, null, null, null, null, null);
            IActionResult result = await controller.Get(It.IsAny<int>());

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task WhenExecuteGetByIdIfElementFoundThenGetOkResult()
        {
            TourDTO tour = new TourDTO();
            Mock<ITourService> mock = new Mock<ITourService>();
            mock.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(tour);

            TourController controller = new TourController(mock.Object, null, null, null, null, null, null, null, null, null);
            IActionResult result = await controller.Get(It.IsAny<int>());
            object resTour = (result as OkObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(resTour, typeof(TourDTO));
            Assert.IsNotNull(resTour as TourDTO);
            Assert.AreEqual(resTour, tour);
        }

        [TestMethod]
        public async Task WhenExecuteAddIfModelIsValidThenGetOkResult()
        {
            TourDTO tour = AddDataTour();
            Mock<ITourService> mock = new Mock<ITourService>();
            mock.Setup(repo => repo.Add(tour)).ReturnsAsync(tour);

            TourController controller = new TourController(mock.Object, null, null, null, null, null, null, null, null, null);
            IActionResult result = await controller.Add(tour);
            object resTour = (result as OkObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(resTour, typeof(TourDTO));
            Assert.IsNotNull(resTour as TourDTO);
        }


        [TestMethod]
        public async Task WhenExecuteAddIfModelIsNotValidThenBadRequestResult()
        {
            TourDTO tour = new TourDTO();
            Mock<ITourService> mock = new Mock<ITourService>();
            mock.Setup(repo => repo.Add(tour)).ReturnsAsync(tour);

            TourController controller = new TourController(mock.Object, null, null, null, null, null, null, null, null, null);
            controller.ModelState.AddModelError("", "");
            IActionResult result = await controller.Add(tour);
            object modelState = (result as BadRequestObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.IsInstanceOfType(modelState, typeof(SerializableError));
            Assert.IsNotNull(modelState as SerializableError);
        }

        [TestMethod]
        public async Task WhenExecuteUpdateIfModelIsValidThenGetOkResult()
        {
            TourDTO tour = AddDataTour();
            Mock<ITourService> mock = new Mock<ITourService>();
            mock.Setup(repo => repo.Get(tour.Id)).ReturnsAsync(tour);
            mock.Setup(repo => repo.Update(tour)).ReturnsAsync(tour);
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            TourController controller = new TourController(mock.Object, null, null, null, null, null, null, null, null, Mapper.Instance);
            IActionResult result = await controller.Update(tour);
            object resTour = (result as OkObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(resTour, typeof(TourDTO));
            Assert.IsNotNull(resTour as TourDTO);
        }

        [TestMethod]
        public async Task WhenExecuteUpdateIfModelIsNotValidThenBadRequestResult()
        {
            TourDTO tour = new TourDTO();
            Mock<ITourService> mock = new Mock<ITourService>();
            mock.Setup(repo => repo.Get(tour.Id)).ReturnsAsync(tour);
            mock.Setup(repo => repo.Update(tour)).ReturnsAsync(tour);

            TourController controller = new TourController(mock.Object, null, null, null, null, null, null, null, null, null);
            controller.ModelState.AddModelError("", "");
            IActionResult result = await controller.Update(tour);
            object modelState = (result as BadRequestObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.IsInstanceOfType(modelState, typeof(SerializableError));
            Assert.IsNotNull(modelState as SerializableError);
        }

        [TestMethod]
        public async Task WhenExecuteDeleteIfIdNotNullThenGetOkResult()
        {
            TourDTO tour = new TourDTO();
            Mock<ITourService> mock = new Mock<ITourService>();
            mock.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(tour);
            mock.Setup(repo => repo.Delete(tour)).ReturnsAsync(tour);

            TourController controller = new TourController(mock.Object, null, null, null, null, null, null, null, null, null);
            IActionResult result = await controller.Delete(It.IsAny<int>());
            object resTour = (result as OkObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(resTour, typeof(TourDTO));
            Assert.IsNotNull(resTour as TourDTO);
        }

        [TestMethod]
        public async Task WhenExecuteDeleteIfIdIsNullThenNotFoundResult()
        {
            TourDTO tour = null;
            Mock<ITourService> mock = new Mock<ITourService>();
            mock.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(tour);
            mock.Setup(repo => repo.Delete(tour)).ReturnsAsync(tour);

            TourController controller = new TourController(mock.Object, null, null, null, null, null, null, null, null, null);
            IActionResult result = await controller.Delete(It.IsAny<int>());

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }


        [TestMethod]
        public async Task WhenExecuteAddCountryIfModelIsValidThenGetOkResult()
        {
            CountryDTO country = new CountryDTO();
            Mock<ICountryService> mock = new Mock<ICountryService>();
            mock.Setup(repo => repo.Add(country)).ReturnsAsync(country);

            TourController controller = new TourController(null, mock.Object, null, null, null, null, null, null, null, null);
            IActionResult result = await controller.AddCountry(country);
            object resCountry = (result as OkObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(resCountry, typeof(CountryDTO));
            Assert.IsNotNull(resCountry as CountryDTO);
        }

        [TestMethod]
        public async Task WhenExecuteAddCountryIfModelNotValidThenBadRequestResult()
        {
            CountryDTO country = null;
            Mock<ICountryService> mock = new Mock<ICountryService>();
            mock.Setup(repo => repo.Add(country)).ReturnsAsync(country);

            TourController controller = new TourController(null, mock.Object, null, null, null, null, null, null, null, null);
            controller.ModelState.AddModelError("", "");
            IActionResult result = await controller.AddCountry(country);
            object modelState = (result as BadRequestObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.IsInstanceOfType(modelState, typeof(SerializableError));
            Assert.IsNotNull(modelState as SerializableError);
        }

        [TestMethod]
        public async Task WhenExecuteAddCityIfModelIsValidThenGetOkResult()
        {
            CityDTO city = new CityDTO();
            Mock<ICityService> mock = new Mock<ICityService>();
            mock.Setup(repo => repo.Add(city)).ReturnsAsync(city);

            TourController controller = new TourController(null, null, mock.Object, null, null, null, null, null, null, null);
            IActionResult result = await controller.AddCity(city);
            object resCountry = (result as OkObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(resCountry, typeof(CityDTO));
            Assert.IsNotNull(resCountry as CityDTO);
        }

        [TestMethod]
        public async Task WhenExecuteAddCityIfModelNotValidThenBadRequestResult()
        {
            CityDTO city = null;
            Mock<ICityService> mock = new Mock<ICityService>();
            mock.Setup(repo => repo.Add(city)).ReturnsAsync(city);

            TourController controller = new TourController(null, null, mock.Object, null, null, null, null, null, null, null);
            controller.ModelState.AddModelError("", "");
            IActionResult result = await controller.AddCity(city);
            object modelState = (result as BadRequestObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.IsInstanceOfType(modelState, typeof(SerializableError));
            Assert.IsNotNull(modelState as SerializableError);
        }

        [TestMethod]
        public async Task WhenExecuteAddHotelIfModelIsValidThenGetOkResult()
        {
            HotelDTO hotel = new HotelDTO();
            Mock<IHotelService> mock = new Mock<IHotelService>();
            mock.Setup(repo => repo.Add(hotel)).ReturnsAsync(hotel);

            TourController controller = new TourController(null, null, null, mock.Object, null, null, null, null, null, null);
            IActionResult result = await controller.AddHotel(hotel);
            object res = (result as OkObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(res, typeof(HotelDTO));
            Assert.IsNotNull(res as HotelDTO);
        }

        [TestMethod]
        public async Task WhenExecuteAddHotelIfModelNotValidThenBadRequestResult()
        {
            HotelDTO hotel = null;
            Mock<IHotelService> mock = new Mock<IHotelService>();
            mock.Setup(repo => repo.Add(hotel)).ReturnsAsync(hotel);

            TourController controller = new TourController(null, null, null, mock.Object, null, null, null, null, null, null);
            controller.ModelState.AddModelError("", "");
            IActionResult result = await controller.AddHotel(hotel);
            object modelState = (result as BadRequestObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.IsInstanceOfType(modelState, typeof(SerializableError));
            Assert.IsNotNull(modelState as SerializableError);
        }

        private TourDTO AddDataTour()
        {
            return new TourDTO
            {
                Id = 1,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now,
                Price = 400,
                CityFrom = new CityFromDTO
                {
                    Id = 1,
                    City = "Минск",
                    Tours = new List<TourDTO>()
                },
                CountOfTours = 3,
                FoodType = new FoodTypeDTO
                {
                    Id = 1,
                    Tours = new List<TourDTO>(),
                    Type = "Все включено"
                },
                Hotel = new HotelDTO
                {
                    Id = 1,
                    Name = "КоралРиф",
                    Stars = 5,
                    PlacementType = new PlacementTypeDTO
                    {
                        Id = 1,
                        Type = "Одноместный",
                        Hotels = new List<HotelDTO>()
                    },
                    City = new CityDTO
                    {
                        Id = 1,
                        Name = "Хургада",
                        Hotels = new List<HotelDTO>(),
                        Country = new CountryDTO
                        {
                            Id = 1,
                            Name = "Египет",
                            Cities = new List<CityDTO>()
                        }
                    },
                    Tours = new List<TourDTO>()
                },
                Orders = new List<OrderDTO>(),
                TourType = new TourTypeDTO(),
                TransportType = new TransportTypeDTO()
            };
        }
    }
}
