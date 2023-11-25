using API.Auth;
using Application.Commands.Animals.CreateAnimal;
using Application.Commands.Animals.DeleteAnimal;
using Application.Commands.Animals.UpdateAnimal;
using Application.Dtos;
using Application.Queries.Animals.GetAll;
using Application.Queries.Animals.GetAnimalById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequireHttps]
    public class AnimalsController : ControllerBase
    {
        internal readonly IMediator _mediator;

        public AnimalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET - Denna endpoint hämtar alla djur från MockDatabase
        [HttpGet]
        [Route("getAllAnimals")]
        public async Task<IActionResult> GetAllAnimals()
        {
            return Ok(await _mediator.Send(new GetAllAnimalsQuery()));
        }

        // GET - Denna kollar ID för alla djur
        [HttpGet]
        [Route("getAnimalById/{animalId}")]
        public async Task<IActionResult> GetAnimalById(Guid animalId)
        {
            return Ok(await _mediator.Send(new GetAnimalByIdQuery(animalId)));
        }

        // POST - skapar nytt Animal api/<AnimalsController>
        [HttpPost]
        [Route("createNewAnimal")]
        public async Task<IActionResult> CreateAnimal([FromBody] AnimalDto newAnimal)
        {
            return Ok(await _mediator.Send(new CreateAnimalCommand(newAnimal)));
        }

        // PUT - Denna uppdaterar Namn via ID
        [HttpPut]
        [Route("updateAnimal/{animalId}")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAnimal([FromBody] AnimalDto updatedAnimal, Guid animalId)
        {
            return Ok(await _mediator.Send(new UpdateAnimalByIdCommand(updatedAnimal, animalId)));
        }

        // DELETE - Denna tar bort Animal via ID
        [HttpDelete]
        [Route("deleteAnimal/{animalId}")]
        // [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> DeleteAnimal(Guid animalId)
        {
            await _mediator.Send(new DeleteAnimalCommand(animalId));
            return Ok();
        }
    }
}
