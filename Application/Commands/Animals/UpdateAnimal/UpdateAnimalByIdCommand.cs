using Application.Dtos;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Animals.UpdateAnimal
{
    public class UpdateAnimalByIdCommand : IRequest<Animal>
    {
        public UpdateAnimalByIdCommand(AnimalDto updatedAnimal, Guid id)
        {
            UpdatedAnimal = updatedAnimal;
            AnimalId = id;
        }

        public AnimalDto UpdatedAnimal { get; }
        public Guid AnimalId { get; }
    }
}
