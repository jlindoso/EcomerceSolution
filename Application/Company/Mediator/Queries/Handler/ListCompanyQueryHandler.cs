using Application.Company.DTO;
using Application.Company.Mediator.Queries.Request;
using Application.Extensions;
using AutoMapper;
using Domain.Exceptions;
using Domain.Ports;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Company.Mediator.Queries.Handler
{
    public class ListCompanyQueryHandler : IRequestHandler<ListCompanyQuery, Response<IEnumerable<CompanyDTO>>>
    {
        private readonly ICompanyReaderRepository _repository;
        private readonly IMapper _mapper;
        public ListCompanyQueryHandler(IMapper mapper, ICompanyReaderRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        

        public async Task<Response<IEnumerable<CompanyDTO>>> Handle(ListCompanyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _repository.List();
                if (model != null)
                    return new(data: _mapper.Map<IEnumerable<CompanyDTO>>(model), success: true, message: "Success");
                throw new InvalidObjectException("Company not found");
            }
            catch (Exception ex)
            {
                return ex.ConvertToResponse<IEnumerable<CompanyDTO>>();
            }
        }
    }
}
