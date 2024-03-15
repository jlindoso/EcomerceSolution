using Application.Company.DTO;
using Application.Company.Mediator.Commands.Request;
using AutoMapper;
using Domain.Ports;
using MediatR;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;

namespace Application.Company.Mediator.Commands.Handler
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Response<CompanyDTO>>
    {
        private readonly ICompanyPersistenceRepository _repository;
        private readonly IMapper _mapper;
        public CreateCompanyCommandHandler(ICompanyPersistenceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<CompanyDTO>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var requestModel = _mapper.Map<Domain.Entities.Company>(request.CompanyCreateRequest);
                if (requestModel.IsValid)
                {
                    var model = await _repository.Create(requestModel);
                    return new(data: _mapper.Map<CompanyDTO>(model), success: true, message: "Company created");
                }
                throw new NoNullAllowedException($"{requestModel.Notifications.FirstOrDefault()?.Message}");
            }
            catch (NoNullAllowedException ex)
            {
                return new(data: null, success: false, message: ex.Message, errorCode: 400);
            }
            catch (Exception)
            {
                return new(data: null, success: false, message: "Unknow error", errorCode: 500);
            }

        }
    }
}
