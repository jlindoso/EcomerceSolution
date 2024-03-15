using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.DTO.Requests
{
    public record CustomerCreateAccountDTO(string UserName, string Email, string Password);
    
}
