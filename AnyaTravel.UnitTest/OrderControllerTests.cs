using AnyaTravel.API.AutoMapperConfig;
using AnyaTravel.API.Controllers;
using AnyaTravel.API.ViewModels;
using AnyaTravel.BLL.Data;
using AnyaTravel.BLL.Infrastructure;
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
    public class OrderControllerTests
    {
        [TestMethod]
        public async Task WhenExecuteGetAllThenGetCollection()
        {
            List<OrderDTO> orders = new List<OrderDTO>
            {
                new OrderDTO(),
                new OrderDTO()
            };
            Mock<IOrderService> mock = new Mock<IOrderService>();
            mock.Setup(repo => repo.Get()).ReturnsAsync(orders);

            OrderController controller = new OrderController(mock.Object, null, null, null);
            IActionResult result = await controller.Get();
            object resOrders = (result as OkObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(resOrders, typeof(IEnumerable<OrderDTO>));
            Assert.IsNotNull(resOrders as IEnumerable<OrderDTO>);
            Assert.AreEqual(resOrders, orders);
        }


        [TestMethod]
        public async Task WhenExecuteAddIfModelIsNotValidThenBadRequestResult()
        {
            OrderDTO order = new OrderDTO();
            Mock<IOrderService> mockOrder = new Mock<IOrderService>();
            Mock<IUserService> mockUser = new Mock<IUserService>();
            Mock<ITourService> mockTour = new Mock<ITourService>();
            mockOrder.Setup(repo => repo.Add(order)).ReturnsAsync(order);
            mockTour.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(new TourDTO());
            mockUser.Setup(repo => repo.GetUser(It.IsAny<string>())).ReturnsAsync(new CurrentUser());
            //Mapper.Initialize(cfg =>
            //       {
            //           cfg.AddProfile(new AutoMapperProfile());
            //       });

            OrderController controller = new OrderController(mockOrder.Object, mockUser.Object, mockTour.Object, Mapper.Instance);
            controller.ModelState.AddModelError("", "");
            IActionResult result = await controller.Add(It.IsAny<int>());
            object modelState = (result as BadRequestObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.IsInstanceOfType(modelState, typeof(SerializableError));
            Assert.IsNotNull(modelState as SerializableError);
        }

        [TestMethod]
        public async Task WhenExecuteUpdateIfModelIsValidThenGetOkResult()
        {
            OrderDTO order = new OrderDTO();
            Mock<IOrderService> mock = new Mock<IOrderService>();
            mock.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(order);
            mock.Setup(repo => repo.Update(order)).ReturnsAsync(order);

            OrderController controller = new OrderController(mock.Object, null, null, null);
            IActionResult result = await controller.Update(It.IsAny<int>());
            object resOrder = (result as OkObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(resOrder, typeof(OrderDTO));
            Assert.IsNotNull(resOrder as OrderDTO);
        }

        [TestMethod]
        public async Task WhenExecuteUpdateIfModelIsNotValidThenBadRequestResult()
        {
            OrderDTO order = new OrderDTO();
            Mock<IOrderService> mock = new Mock<IOrderService>();
            mock.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(order);
            mock.Setup(repo => repo.Update(order)).ReturnsAsync(order);

            OrderController controller = new OrderController(mock.Object, null, null, null);
            controller.ModelState.AddModelError("", "");
            IActionResult result = await controller.Update(It.IsAny<int>());
            object modelState = (result as BadRequestObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.IsInstanceOfType(modelState, typeof(SerializableError));
            Assert.IsNotNull(modelState as SerializableError);
        }

        [TestMethod]
        public async Task WhenExecuteDeleteIfIdNotNullThenGetOkResult()
        {
            OrderDTO order = new OrderDTO();
            Mock<IOrderService> mock = new Mock<IOrderService>();
            mock.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(order);
            mock.Setup(repo => repo.Delete(order)).ReturnsAsync(order);

            OrderController controller = new OrderController(mock.Object, null, null, null);
            IActionResult result = await controller.Delete(It.IsAny<int>());
            object resOrder = (result as OkObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(resOrder, typeof(OrderDTO));
            Assert.IsNotNull(resOrder as OrderDTO);
        }

        [TestMethod]
        public async Task WhenExecuteDeleteIfIdIsNullThenNotFoundResult()
        {
            OrderDTO order = null;
            Mock<IOrderService> mock = new Mock<IOrderService>();
            mock.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(order);
            mock.Setup(repo => repo.Delete(order)).ReturnsAsync(order);

            OrderController controller = new OrderController(mock.Object, null, null, null);
            IActionResult result = await controller.Delete(It.IsAny<int>());

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
