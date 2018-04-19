using System;
using System.ComponentModel.DataAnnotations;

namespace AnyaTravel.API.ViewModels
{
    public class SignUp
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FIO { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
    }
}
