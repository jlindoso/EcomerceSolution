using EcomerceDomain.Models.Base;
using EcomerceDomain.Models.StoreDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceDomain.Models.Order
{
    public class Order: BaseModel
    {
        public Guid StoreId { get; set; }
        public virtual Store Store { get; set; } = new();
        public bool Status { get; set; }
    }
}
