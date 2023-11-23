using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Animals.DeleteAnimal
{
    internal class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand, Unit>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteAnimalCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Unit> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            // Find and remove the dog from the database with the ID
            Animal animalToDelete = _mockDatabase.allAnimals.FirstOrDefault(animal => animal.animalId == request.AnimalId)!;


            if (animalToDelete != null)
            {
                // Determine the type of the animal and remove it from the appropriate list
                if (animalToDelete is Dog dogToDelete)
                {
                    _mockDatabase.allDogs.Remove(dogToDelete);
                }
                else if (animalToDelete is Cat catToDelete)
                {
                    _mockDatabase.allCats.Remove(catToDelete);
                }
                else if (animalToDelete is Bird birdToDelete)
                {
                    _mockDatabase.allBirds.Remove(birdToDelete);
                }
            }

            return Task.FromResult(Unit.Value);
        }
    }
}
