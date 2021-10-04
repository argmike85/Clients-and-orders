using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_orders.Abstraction.ClientModels
{
    public class UpdateClientModel : CreateClientModel
    {
        public int ClientId { get; set; }
    }
}
