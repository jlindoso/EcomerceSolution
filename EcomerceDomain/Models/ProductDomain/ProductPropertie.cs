using EcomerceDomain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceDomain.Models.ProductDomain
{
    public class ProductPropertie: BaseModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = new();
    }
}
