using Application.Dtos;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommand : IRequest<Dog>
    {
        public UpdateDogByIdCommand(DogDto updatedDog, Guid id)
        {
            UpdatedDog = updatedDog;
            animalId = id;
        }

        public DogDto UpdatedDog { get; }
        public Guid animalId { get; }
    }
}
