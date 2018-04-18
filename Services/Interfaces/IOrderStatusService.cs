using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    interface IOrderStatusService: IService<OrderStatus, int>
    {
    }
}
