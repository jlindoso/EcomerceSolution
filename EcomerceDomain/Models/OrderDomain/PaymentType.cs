using EcomerceDomain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceDomain.Models.OrderDomain
{
    public class PaymentType: BaseModel
    {
        public string Name { get; set; }
    }
}
