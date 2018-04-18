using System;
using System.Collections.Generic;
using System.Text;

namespace AnyaTravel.BLL.Data
{
    public class CurrentUser
    {
        public string Id { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public bool IsAuntificated { get; set; }
        public string FIO { get; set; }
        public string Passport { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }

        public CurrentUser()
        {
            Roles = new List<string>();
            IsAuntificated = false;
            FIO = string.Empty;
            Passport = string.Empty;
            Birthday = DateTime.Today;
            Email = string.Empty;
            Login = string.Empty;
        }

    }
}
