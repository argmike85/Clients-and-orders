using Client_orders.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_orders.Abstraction.OrderModels
{
    public class CreateOrderModel
    {
    
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public Status Status { get; set; }
        public int ClientId { get; set; }
 
    }
}
