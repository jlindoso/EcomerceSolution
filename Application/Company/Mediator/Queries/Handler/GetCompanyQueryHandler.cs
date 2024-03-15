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
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, Response<CompanyDTO>>
    {
        private readonly ICompanyReaderRepository _repository;
        private readonly IMapper _mapper;
        public GetCompanyQueryHandler(IMapper mapper, ICompanyReaderRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        

        public async Task<Response<CompanyDTO>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _repository.Get(request.Id);
                if (model != null)
                    return new(data: _mapper.Map<CompanyDTO>(model), success: true, message: "Success");
                throw new InvalidObjectException("Company not found");
            }
            catch (Exception ex)
            {
                return ex.ConvertToResponse<CompanyDTO>();
            }
        }
    }
}
