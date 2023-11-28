using Application.Commands.Animals.CreateAnimal;
using Application.Commands.Animals.DeleteAnimal;
using Application.Commands.Animals.UpdateAnimal;
using Application.Dtos;
using Application.Queries.Animals.GetAll;
using Application.Queries.Animals.GetAnimalById;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        // POST - skapar nytt Animal om du är Authorized
        [HttpPost]
        [Route("createNewAnimal")]
        [Authorize]
        public async Task<IActionResult> CreateAnimal([FromBody] AnimalDto newAnimal)
        {
            return Ok(await _mediator.Send(new CreateAnimalCommand(newAnimal)));
        }

        // PUT - Denna uppdaterar Namn via ID om du är Authorized
        [HttpPut]
        [Route("updateAnimal/{animalId}")]
        [Authorize]
        public async Task<IActionResult> UpdateAnimal([FromBody] AnimalDto updatedAnimal, Guid animalId)
        {
            return Ok(await _mediator.Send(new UpdateAnimalByIdCommand(updatedAnimal, animalId)));
        }

        // DELETE - Denna tar bort Animal via ID om du är Authorized
        [HttpDelete]
        [Route("deleteAnimal/{animalId}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> DeleteAnimal(Guid animalId)
        {
            try
            {
                var animalDto = await _mediator.Send(new GetAnimalByIdQuery(animalId));

                if (animalDto == null)
                {
                    return NotFound(new { Message = "Animal not found." });
                }

                await _mediator.Send(new DeleteAnimalCommand(animalId));
                return Ok(new { Message = $"{animalDto.Name} has been sent to the shadow realm." });
            }
            catch (Exception)
            {
                // Handle other exceptions
                return StatusCode(500, new { Message = "An error occurred while processing your request." });
            }
        }
    }
}
