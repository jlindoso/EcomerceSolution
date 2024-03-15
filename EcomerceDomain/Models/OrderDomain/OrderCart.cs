using EcomerceDomain.Models.Base;
using EcomerceDomain.Models.ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceDomain.Models.OrderDomain
{
    public class OrderCart: BaseModel
    {
        public Guid StockProductId { get; set; }
        public virtual StockProduct StockProduct { get; set; } = new();
        public decimal Price { get; set; } = 0.0M;
        public int Qtd { get; set; } = 0;
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; } = new();

    }
}
