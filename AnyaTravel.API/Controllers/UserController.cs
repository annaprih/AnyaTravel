using System.Collections.Generic;
using System.Threading.Tasks;
using AnyaTravel.API.ViewModels;
using AnyaTravel.BLL.Data;
using AnyaTravel.BLL.Infrastructure;
using AnyaTravel.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnyaTravel.API.Controllers
{
    [Produces("application/json")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        //TODO: delete in prod
      //  [Authorize(Roles = "Admin")]
        [Route("api/user")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<UserDTO> users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpPut]
        [Route("api/user")]
        public async Task<IActionResult> Update(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                CurrentUser user = await _userService.GetUser(User.Identity.Name);
              
                if(user!=null)
                {
                    user.Birthday = userModel.Birthday;
                    user.FIO = userModel.FIO;
                    OperationResult result = await _userService.UpdateUser(user);
                    return Ok(result);
                }

                return NotFound();
            }
            return BadRequest(ModelState);
        }
    }
}
