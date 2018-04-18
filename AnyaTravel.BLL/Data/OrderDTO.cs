using System;

namespace AnyaTravel.BLL.Data
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int Price { get; set; }

        public  UserDTO User { get; set; }

        public  TourDTO Tour { get; set; }

        public  OrderStatusDTO OrderStatus { get; set; }
    }
}
