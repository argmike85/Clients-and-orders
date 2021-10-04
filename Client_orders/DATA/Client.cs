using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Client_orders.CustomValidation;


namespace Client_orders.DATA
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required(ErrorMessage ="заполните Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage ="заполните ДР")]
        public DateTime BirthDate { get; set; }
       
        [RegularExpression(pattern: @"^[0-9]{10}$|^[0-9]{12}$", ErrorMessage = "Неккоректный ИНН")]
     
        public string Inn { get; set; }
        [Required(ErrorMessage ="заполните Телефон")]
        public string PhoneNumber { get; set; }
        [RegularExpression(pattern:@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage ="Неккоректный адрес email")]
        public string Email { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
