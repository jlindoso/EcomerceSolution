using EcomerceDomain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceDomain.Models.StoreDomain
{
    public class Store : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CNPJ { get; set; }
        public Guid GroupStoreId { get; set; }
        public virtual GroupStore GroupStore {get; set;} = new();


    }
}
