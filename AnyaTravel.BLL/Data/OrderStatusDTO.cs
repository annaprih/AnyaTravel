using System.Collections.Generic;

namespace AnyaTravel.BLL.Data
{
    public class OrderStatusDTO
    {
        public int Id { get; set; }
        public int Status { get; set; }

        public  List<OrderDTO> Orders { get; set; }
    }
}
