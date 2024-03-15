using EcomerceDomain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceDomain.Models.ProductDomain
{
    public class StockProduct: BaseModel
    {
        public int Qtd { get; set; } = 0;
        public decimal CostPriceUnity { get; set; } = 0.0M;
        public decimal SellPrice { get; set; } = 0.0M;
        public Guid StockId { get; set; }
        public virtual Stock Stock { get; set; } = new();
    }
}
