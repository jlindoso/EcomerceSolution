using Application.Company.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Company.Mediator.Queries.Request
{
    public class ListCompanyQuery : IRequest<Response<IEnumerable<CompanyDTO>>>
    {
    }
}
