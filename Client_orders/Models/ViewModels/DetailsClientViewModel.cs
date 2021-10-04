using Client_orders.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_orders.Models.ViewModels
{
    public class DetailsClientViewModel
    {
        public Client Client { get; set; }
        public List<Order> Orders { get; set; }

    }
}
