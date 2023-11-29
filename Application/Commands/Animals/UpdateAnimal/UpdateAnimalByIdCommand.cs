using Application.Dtos;
using Domain.Models;
using MediatR;

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
