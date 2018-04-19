using System.Threading.Tasks;
using AnyaTravel.API.ViewModels;
using AnyaTravel.BLL.Data;
using AnyaTravel.BLL.Infrastructure;
using AnyaTravel.BLL.Interfaces;
using AnyaTravel.DAL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Identity = Microsoft.AspNetCore.Identity;

namespace AnyaTravel.API.Controllers
{
    [Produces("application/json")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IEmailService emailService, UserManager<User> userManager, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
            _emailService = emailService;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("api/auth/login")]
        public async Task<IActionResult> Login([FromBody]SignIn signIn)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDto = _mapper.Map<SignIn, UserDTO>(signIn);
                User user = await _userManager.FindByNameAsync(userDto.Login);

                if (user != null)
                {
                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        return Unauthorized();
                    }
                    else
                    {
                        Identity.SignInResult result = await _userService.SignIn(userDto);
                        return Ok(result.Succeeded);
                    }
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("api/auth/externalLogin")]
        public async Task<IActionResult> ExternalLogin([FromBody]SignUp externelUser)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(externelUser.Login);
                if (user != null)
                {
                    return await Login(new SignIn { Login = externelUser.Login, Password = externelUser.Password });
                }
                IActionResult result = await SignUp(externelUser);
                User newUser = await _userManager.FindByNameAsync(externelUser.Login);
                string code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                await _userManager.ConfirmEmailAsync(newUser, code);
                return await Login(new SignIn { Login = externelUser.Login, Password = externelUser.Password });
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("api/auth/logout")]
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return Ok();
        }

        [HttpPost]
        [Route("api/auth/registration")]
        public async Task<IActionResult> SignUp([FromBody]SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDto = _mapper.Map<SignUp, UserDTO>(signUp);

                OperationResult operationResult = await _userService.SignUp(userDto);
                if (operationResult.Result)
                {
                    User user = await _userManager.FindByEmailAsync(userDto.Email);
                    string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    string callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Auth",
                        new { userId = user.Id, code = code },
                        protocol: HttpContext.Request.Scheme
                    );
                    await _emailService.SendEmailAsync(user.Email, "Confirm your account", GetEmailMessageText(callbackUrl));
                }

                return Ok(operationResult);
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("api/auth/user")]
        public async Task<CurrentUser> GetCurrentUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                CurrentUser user = await _userService.GetUser(User.Identity.Name);
                user.IsAuntificated = true;
                return user;
            }
            return new CurrentUser();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId != null && code != null)
            {
                User user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    IdentityResult result = await _userManager.ConfirmEmailAsync(user, code);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return BadRequest();
        }

        private string GetEmailMessageText(string url)
        {
            return $"Подтвердите регистрацию, перейдя по ссылке: <a href='{url}'>link</a>";
        }
    }
}
