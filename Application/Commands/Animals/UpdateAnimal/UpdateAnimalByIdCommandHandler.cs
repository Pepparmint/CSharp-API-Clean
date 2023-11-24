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
    public class UpdateAnimalByIdCommandHandler : IRequestHandler<UpdateAnimalByIdCommand, Animal>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateAnimalByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Animal> Handle(UpdateAnimalByIdCommand request, CancellationToken cancellationToken)
        {
            Animal animalToUpdate = _mockDatabase.allAnimals.FirstOrDefault(animal => animal.animalId == request.AnimalId)!;

            if (animalToUpdate != null)
            {
                // Update the name of the animal
                animalToUpdate.Name = request.UpdatedAnimal.Name;

                // Check if the type has changed
                if (!string.Equals(animalToUpdate.Type, request.UpdatedAnimal.Type, StringComparison.OrdinalIgnoreCase))
                {
                    // Remove the old animal from the list corresponding to its old type
                    switch (animalToUpdate)
                    {
                        case Dog oldDog when _mockDatabase.allDogs.Contains(oldDog):
                            _mockDatabase.allDogs.Remove(oldDog);
                            break;

                        case Cat oldCat when _mockDatabase.allCats.Contains(oldCat):
                            _mockDatabase.allCats.Remove(oldCat);
                            break;

                        case Bird oldBird when _mockDatabase.allBirds.Contains(oldBird):
                            _mockDatabase.allBirds.Remove(oldBird);
                            break;
                    }

                    // Create a new instance of the appropriate derived class based on the updated type
                    Animal updatedAnimal = request.UpdatedAnimal.Type.ToLower() switch
                    {
                        "dog" => new Dog(),
                        "cat" => new Cat(),
                        "bird" => new Bird(),
                        _ => new Animal() // Handle unknown types or provide a default type
                    };

                    // Set common properties
                    updatedAnimal.animalId = animalToUpdate.animalId; // Keep the same ID
                    updatedAnimal.Name = request.UpdatedAnimal.Name;

                    // Add the updated animal to the new list
                    switch (updatedAnimal)
                    {
                        case Dog dog:
                            _mockDatabase.allDogs.Add(dog);
                            break;

                        case Cat cat:
                            _mockDatabase.allCats.Add(cat);
                            break;

                        case Bird bird:
                            _mockDatabase.allBirds.Add(bird);
                            break;
                    }

                    // Remove the old animal from the combined list
                    _mockDatabase.allAnimals.Remove(animalToUpdate);

                    // Return the updated animal
                    return Task.FromResult(updatedAnimal);
                }

                // Return the updated animal without changing the type
                return Task.FromResult(animalToUpdate);
            }

            return Task.FromResult<Animal>(null!);
        }

    }
}
