using EcomerceDomain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceDomain.Models.ProductDomain
{
    public class Stock : BaseModel
    {
        public string Invoice { get; set; }
        public int TotalItems { get; set; } = 0;
        public decimal TotalPrice { get; set; } = 0.0M;
    }
}
