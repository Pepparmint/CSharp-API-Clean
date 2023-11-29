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
    public class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand, Unit>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteAnimalCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Unit> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            // Find and remove the animal from the database with the ID
            Animal animalToDelete = _mockDatabase.allAnimals.FirstOrDefault(animal => animal.animalId == request.AnimalId)!;

            if (animalToDelete != null)
            {
                // Determine the type of the animal and remove it from the appropriate list
                switch (animalToDelete)
                {
                    case Dog dogToDelete when _mockDatabase.allDogs.Contains(dogToDelete): _mockDatabase.allDogs.Remove(dogToDelete); break;
                    case Cat catToDelete when _mockDatabase.allCats.Contains(catToDelete): _mockDatabase.allCats.Remove(catToDelete); break;
                    case Bird birdToDelete when _mockDatabase.allBirds.Contains(birdToDelete): _mockDatabase.allBirds.Remove(birdToDelete); break;
                }
            }
            return Task.FromResult(Unit.Value);
        }
    }
}
