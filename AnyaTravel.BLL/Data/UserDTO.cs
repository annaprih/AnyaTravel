using System;
using System.Collections.Generic;

namespace AnyaTravel.BLL.Data
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FIO { get; set; }
        public DateTime Birthday { get; set; }
        public  List<OrderDTO> Orders { get; set; }

        public UserDTO()
        {
            Orders = new List<OrderDTO>();
        }
    }
}
