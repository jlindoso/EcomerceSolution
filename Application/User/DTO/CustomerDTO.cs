using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.DTO
{
    public class CustomerDTO()
    {
        public Guid Id  {get; set;}
        public string Name  {get; set;}
        public string Email { get; set; }
    }
}
