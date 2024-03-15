using EcomerceDomain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceDomain.Models.OrderDomain
{
    public class Payment: BaseModel
    {
        public decimal Value { get; set; } = 0.0M;
        public Guid PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; } = new();
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; } = new();
    }
}
