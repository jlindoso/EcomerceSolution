using Application.Company.DTO;
using Application.Extensions;
using Application.User.DTO;
using Application.User.Mediator.Queries.Request;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace Application.User.Mediator.Queries.Handler
{
    public class ListCustomersQueryHandler : IRequestHandler<ListCustomersQuery, Response<IEnumerable<CustomerDTO>>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        public ListCustomersQueryHandler(UserManager<IdentityUser> manager, IMapper mapper)
        {
            _userManager = manager;
            _mapper = mapper;
        }
        async Task<Response<IEnumerable<CustomerDTO>>> IRequestHandler<ListCustomersQuery, Response<IEnumerable<CustomerDTO>>>.Handle(ListCustomersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await Task.Run(() =>_userManager.Users.ToList());
                return new Response<IEnumerable<CustomerDTO>>(data: _mapper.Map<IEnumerable<CustomerDTO>>(users), 
                                                              success: true, 
                                                              message: "List of users");

            }
            catch (Exception ex)
            {
                return ex.ConvertToResponse<IEnumerable<CustomerDTO>>();
            }
        }
    }
}
