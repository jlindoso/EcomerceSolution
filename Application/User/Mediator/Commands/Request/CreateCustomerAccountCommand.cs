using Application.Company.DTO;
using Application.User.DTO;
using Application.User.DTO.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Mediator.Commands.Request
{
    public class CreateCustomerAccountCommand : IRequest<Response<CustomerDTO>>
    {
        public CustomerCreateAccountDTO CustomerCreateAccountDTO { get; set; }
    }
}
