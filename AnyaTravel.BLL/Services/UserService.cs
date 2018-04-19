using AnyaTravel.BLL.Data;
using AnyaTravel.BLL.Infrastructure;
using AnyaTravel.BLL.Interfaces;
using AnyaTravel.DAL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnyaTravel.BLL.Services
{
    public class UserService : IUserService
    {

        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        async Task<SignInResult> IUserService.SignIn(UserDTO user)
        {
            return await _signInManager.PasswordSignInAsync(user.Login, user.Password, true, false);
        }

        async Task IUserService.Logout()
        {
            await _signInManager.SignOutAsync();
        }

        async Task<OperationResult> IUserService.SignUp(UserDTO userDto)
        {
            IdentityResult result = await AddUser(userDto);
            OperationResult operationResult = new OperationResult
            {
                Result = result.Succeeded,
                Errors = result.Errors.Select(p => p.Description)
            };
            return operationResult;
        }

        async Task<IEnumerable<UserDTO>> IUserService.GetUsers()
        {
            IEnumerable<User> users = await Task.Factory.StartNew(() => _userManager.Users.ToList());
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }

        async Task<OperationResult> IUserService.DeleteUser(User user)
        {
            IdentityResult result = await _userManager.DeleteAsync(user);
            OperationResult operationResult = new OperationResult
            {
                Result = result.Succeeded,
                Errors = result.Errors.Select(p => p.Description)
            };
            return operationResult;
        }



        async Task<IEnumerable<string>> IUserService.GetUserRoles(string userName)
        {
            User userDb = await _userManager.FindByNameAsync(userName);
            return await _userManager.GetRolesAsync(userDb);
        }

        async Task<CurrentUser> IUserService.GetUser(string userName)
        {
            User userDb = await _signInManager.UserManager.FindByNameAsync(userName);
            if (userDb != null)
            {
                CurrentUser user = new CurrentUser
                {
                    Id = userDb.Id,
                    Roles = await _signInManager.UserManager.GetRolesAsync(userDb),
                    FIO = userDb.FIO,
                    Birthday = userDb.Birthday,
                    Email = userDb.Email,
                    Login = userDb.UserName
                };
                return user;
            }
            return null;
        }

        private async Task<IdentityResult> AddUser(UserDTO userDto)
        {
            User user = new User
            {
                Email = userDto.Email,
                UserName = userDto.Login,
                FIO = userDto.FIO,
                Birthday = userDto.Birthday
            };
            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);
            return result;
        }

        async Task<User> IUserService.GetUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        async Task<OperationResult> IUserService.AddToRole(User user, string role)
        {
            IdentityResult result = await _userManager.AddToRoleAsync(user, role);
            OperationResult operationResult = new OperationResult
            {
                Result = result.Succeeded,
                Errors = result.Errors.Select(p => p.Description)
            };
            return operationResult;
        }

        async Task IUserService.SeedDatabse()
        {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            User user = new User
            {
                UserName = "anna_prih",
                EmailConfirmed = true,
                Email = "anna_prih@tut.by",
                FIO = "Прихач Анна Александровна",
                Birthday = new DateTime(1998, 4, 8)
            };
            await _userManager.CreateAsync(user, "a80291227107_A");
            await _userManager.AddToRoleAsync(user, "Admin");
        }

        async Task<OperationResult> IUserService.UpdateUser(CurrentUser currentUser)
        {
            User user = await _userManager.FindByNameAsync(currentUser.Login);
            user.FIO = currentUser.FIO;
            user.Birthday = currentUser.Birthday;
            IdentityResult result =  await _userManager.UpdateAsync(user);
            OperationResult operationResult = new OperationResult
            {
                Result = result.Succeeded,
                Errors = result.Errors.Select(p => p.Description)
            };
            return operationResult;
        }
    }
}
