using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_orders.Abstraction.OrderModels
{
    public class UpdateOrderModel : CreateOrderModel
    {
        public int OrderId { get; set; }
    }
}
