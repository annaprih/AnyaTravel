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
    public class UserControllerTests
    {
        [TestMethod]
        public async Task WhenExecuteUpdateIfModelIsNotValidThenBadRequestResult()
        {
            CurrentUser user = new CurrentUser();
            Mock<IUserService> mock = new Mock<IUserService>();
            mock.Setup(repo => repo.GetUser(It.IsAny<string>())).ReturnsAsync(user);
            mock.Setup(repo => repo.UpdateUser(user)).ReturnsAsync(new OperationResult());

            UserController controller = new UserController(mock.Object);
            controller.ModelState.AddModelError("", "");
            IActionResult result = await controller.Update(null);
            object modelState = (result as BadRequestObjectResult)?.Value;

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.IsInstanceOfType(modelState, typeof(SerializableError));
            Assert.IsNotNull(modelState as SerializableError);
        }

    }
}
