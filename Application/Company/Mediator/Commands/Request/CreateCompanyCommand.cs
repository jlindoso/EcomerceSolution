using Application.Company.DTO;
using Application.Company.DTO.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Company.Mediator.Commands.Request
{
    public class CreateCompanyCommand : IRequest<Response<CompanyDTO>>
    {
        public CompanyCreateRequest CompanyCreateRequest { get; set; }
    }
}
