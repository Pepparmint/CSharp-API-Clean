﻿using Infrastructure.Database;
using MediatR;
using Application.Queries.Dogs.GetAll;
using Application.Queries.Dogs.GetDogById;
using Application.Commands.Dogs.CreateDog;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        // Denna API endpoint hämtas alla hundar ifrån MockDatabase
        [HttpGet]
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {
            return Ok(await _mediator.Send(new GetAllDogsQuery()));
        }

        // GET api/<DogsController>
        [HttpGet]
        [Route("getDogById/{dogId}")]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            return Ok(await _mediator.Send(new GetDogByIdQuery(dogId)));
        }

        // POST api/<DogsController>
        [HttpPost]
        [Route("createNewDog")]
        public async Task<IActionResult> CreateDog([FromBody] DogDto newDog)
        {
            return Ok(await _mediator.Send(new CreateDogCommand(newDog)));
        }

        // PUT api/<DogsController>
        [HttpPut]
        [Route("updateDog/{updatedDogId}")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto updatedDog, Guid updatedDogId)
        {
            return Ok(await _mediator.Send(new UpdateDogByIdCommand(updatedDog, updatedDogId)));
        }

        // DELETE api/<DogsController>
        [HttpDelete]
        [Route("deleteDog/{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
