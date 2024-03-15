using Application.Company.DTO;
using Application.User.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Mediator.Queries.Request
{
    public class ListCustomersQuery: IRequest<Response<IEnumerable<CustomerDTO>>>
    {
        
    }
}
