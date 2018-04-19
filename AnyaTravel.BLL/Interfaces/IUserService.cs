using AnyaTravel.BLL.Data;
using AnyaTravel.BLL.Infrastructure;
using AnyaTravel.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnyaTravel.BLL.Interfaces
{
    public interface IUserService
    {
        Task<SignInResult> SignIn(UserDTO user);
        Task<OperationResult> SignUp(UserDTO user);
        Task Logout();
        Task<CurrentUser> GetUser(string userName);
        Task<User> GetUserById(string id);
        Task<IEnumerable<string>> GetUserRoles(string userName);
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<OperationResult> DeleteUser(User user);
        Task<OperationResult> UpdateUser(CurrentUser user);

        Task<OperationResult> AddToRole(User user, string role);
        Task SeedDatabse();

    }
}
