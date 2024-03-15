using Application;
using Application.Company.DTO;

using Application.Company.DTO.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Company.Mediator.Queries.Request;
using Application.Company.Mediator.Commands.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
       
        private readonly IMediator _mediator;
        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
       
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> Get()
        {
            var response = await _mediator.Send(new ListCompanyQuery());

            if (response.Success) return Ok(response);
            else
            {
                if (response.ErrorCode == 404) return NotFound(response);
                else return StatusCode(500, response);
            }
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response<CompanyDTO>>> Get(Guid id)
        {
            var query = new GetCompanyQuery
            {
                Id = id
            };
            var response = await _mediator.Send(query);

            if (response.Success) return Ok(response);
            else
            {
                if (response.ErrorCode == 404) return NotFound(response);
                else return StatusCode(500, response);
            }
        }

        // POST api/<CompanyController>
        /// <summary>
        /// Create a new Company
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response<CompanyDTO>>> Post([FromBody] CompanyCreateRequest request)
        {
            var command = new CreateCompanyCommand
            {
                CompanyCreateRequest = request
            };
            var result = await _mediator.Send(command);
            if (result.Success) return Created("", result);
            return BadRequest(result);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
