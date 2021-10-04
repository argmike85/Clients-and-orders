using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client_orders.DATA
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "заполните название заказа")]
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "выберите статус заказа")]
        public Status Status { get; set; }
        public int ClientId { get; set; }
        public virtual Client Clients { get; set; }
    }

}
