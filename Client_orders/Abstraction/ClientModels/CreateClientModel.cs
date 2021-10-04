using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client_orders.CustomValidation;
namespace Client_orders.Abstraction.ClientModels
{
    public class CreateClientModel
    {
        public string Name { get; set; }
   
        public DateTime BirthDate { get; set; }
        public string Inn { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
  
    }
}
