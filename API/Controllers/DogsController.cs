using Infrastructure.Database;
using MediatR;
using Application.Queries.Dogs;
using Application.Queries.Dogs.GetDogById;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// CQRS - Command Query Responsibility Segratation

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        internal readonly IMediator _mediator;

        public DogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Detta är API endpoint där vi hämtar alla hundar ifrån MockDatabase
        [HttpGet]
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {
            return Ok(await _mediator.Send(new GetAllDogsQuery()));
        }

        // GET api/<DogsController>/5
        [HttpGet]
        [Route("getDogById/{dogId}")]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            return Ok(await _mediator.Send(new GetDogByIdQuery(dogId)));
        }

        // POST api/<DogsController>
        [HttpPost]
        [Route("createNewDog")]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<DogsController>/5
        [HttpPut]
        [Route("updateDog/{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<DogsController>/5
        [HttpDelete]
        [Route("deleteDog/{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
