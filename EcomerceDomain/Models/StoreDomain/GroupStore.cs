using EcomerceDomain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceDomain.Models.StoreDomain
{
    public class GroupStore: BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
