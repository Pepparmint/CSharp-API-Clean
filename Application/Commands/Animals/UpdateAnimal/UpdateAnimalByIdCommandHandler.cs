using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Animals.UpdateAnimal
{
    internal class UpdateAnimalByIdCommandHandler : IRequestHandler<UpdateAnimalByIdCommand, Animal>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateAnimalByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Animal> Handle(UpdateAnimalByIdCommand request, CancellationToken cancellationToken)
        {
            // Find the animal in the database with the ID
            Animal animalToUpdate = _mockDatabase.allAnimals.FirstOrDefault(animal => animal.animalId == request.AnimalId)!;

            if (animalToUpdate != null)
            {
                // Update the name of the animal
                animalToUpdate.Name = request.UpdatedAnimal.Name;

                // Return the updated animal
                return Task.FromResult(animalToUpdate);
            }

            // Return null if the animal is not found
            return Task.FromResult<Animal>(null!);
        }
    }
}
