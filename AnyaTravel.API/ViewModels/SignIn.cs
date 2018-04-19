using System.ComponentModel.DataAnnotations;

namespace AnyaTravel.API.ViewModels
{
    public class SignIn
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
