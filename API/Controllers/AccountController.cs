using Application.Company.DTO;
using Application;
using Application.User.DTO.Requests;
using Microsoft.AspNetCore.Mvc;
using Application.User.DTO;
using Application.Company.Mediator.Commands.Request;
using MediatR;
using Application.User.Mediator.Commands.Request;
using Application.User.Mediator.Queries.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {

            _mediator = mediator;

        }
        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<CustomerDTO>>>> Users()
        {
            var result = await _mediator.Send(new ListCustomersQuery());
            if (result.Success) return Ok(result);
            return NotFound(result);
        }

        //// GET api/<CustomerController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<ActionResult<Response<CustomerDTO>>> SignUp([FromBody] CustomerCreateAccountDTO model)
        {
            var command = new CreateCustomerAccountCommand
            {
                CustomerCreateAccountDTO = model
            };
            var result = await _mediator.Send(command);
            if (result.Success) return Created("", result);
            return BadRequest(result);
        }

        //// PUT api/<CustomerController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CustomerController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
