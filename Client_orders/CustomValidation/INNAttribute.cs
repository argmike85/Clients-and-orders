using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client_orders.CustomValidation
{
    public class INNAttribute:ValidationAttribute
    {
        public INNAttribute():base("{0} Date should ")
        { 
        
        }

        public override bool IsValid(object value)
        {
            DateTime propValue = Convert.ToDateTime(value);
            if (propValue <= DateTime.Now)
                return true;
            else
                return false;
        }

     
    }
}
