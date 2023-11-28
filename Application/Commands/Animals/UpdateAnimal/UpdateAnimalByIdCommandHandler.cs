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
            Animal animalToUpdate = _mockDatabase.allAnimals.FirstOrDefault(animal => animal.animalId == request.AnimalId);

            if (animalToUpdate == null)
            {
                return Task.FromResult<Animal>(null!);
            }

            // Update the name of the animal
            animalToUpdate.Name = request.UpdatedAnimal.Name;

            // Check if the type has changed
            if (!string.Equals(animalToUpdate.Type, request.UpdatedAnimal.Type, StringComparison.OrdinalIgnoreCase))
            {
                RemoveAnimalFromList(animalToUpdate);

                Animal updatedAnimal = CreateUpdatedAnimal(request, animalToUpdate);

                updatedAnimal.animalId = animalToUpdate.animalId; // Keep the same ID

                AddAnimalToList(updatedAnimal);

                _mockDatabase.allAnimals.Remove(animalToUpdate);

                return Task.FromResult(updatedAnimal);
            }
            return Task.FromResult(animalToUpdate);
        }

        private void RemoveAnimalFromList(Animal animal)
        {
            if (animal is Dog dog && _mockDatabase.allDogs.Contains(dog))
            {_mockDatabase.allDogs.Remove(dog);}
            else if (animal is Cat cat && _mockDatabase.allCats.Contains(cat))
            {_mockDatabase.allCats.Remove(cat);}
            else if (animal is Bird bird && _mockDatabase.allBirds.Contains(bird))
            {_mockDatabase.allBirds.Remove(bird);}
        }

        private void AddAnimalToList(Animal animal)
        {
            switch (animal)
            {
                case Dog dog: _mockDatabase.allDogs.Add(dog); break;
                case Cat cat: _mockDatabase.allCats.Add(cat); break;
                case Bird bird: _mockDatabase.allBirds.Add(bird); break;
            }
        }

        private Animal CreateUpdatedAnimal(UpdateAnimalByIdCommand request, Animal existingAnimal)
        {
            Animal updatedAnimal = request.UpdatedAnimal.Type.ToLower() switch
            {
                "dog" => new Dog(),
                "cat" => new Cat(),
                "bird" => new Bird(),
                _ => new Animal() // Handle unknown types or provide a default type
            };

            // Set common properties
            updatedAnimal.Name = request.UpdatedAnimal.Name;

            return updatedAnimal;
        }
    }
}
