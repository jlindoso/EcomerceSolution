using Application.Company.DTO;
using Application.Company.Mediator.Commands.Request;
using Application.Extensions;
using Application.User.DTO;
using Application.User.DTO.Requests;
using Application.User.Mediator.Commands.Request;
using AutoMapper;
using Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace Application.User.Mediator.Commands.Handler
{
    public class CreateCustormerAccountCommandHandler : IRequestHandler<CreateCustomerAccountCommand, Response<CustomerDTO>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        public CreateCustormerAccountCommandHandler(UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Response<CustomerDTO>> Handle(CreateCustomerAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var requestModel = _mapper.Map<IdentityUser>(request.CustomerCreateAccountDTO);

                var user = await _userManager.CreateAsync(requestModel, request.CustomerCreateAccountDTO.Password);
                var claim = await _userManager.AddClaimAsync(requestModel, new("Name", request.CustomerCreateAccountDTO.UserName));

                if (!user.Succeeded)
                    throw new NoNullAllowedException($"{user.Errors.FirstOrDefault().Description}");
                return new(data: _mapper.Map<CustomerDTO>(requestModel), success: true, message: "Account created");
            }
            catch (NoNullAllowedException ex)
            {
                return ex.ConvertToResponse<CustomerDTO>();
            }
           
        }
    }
}
