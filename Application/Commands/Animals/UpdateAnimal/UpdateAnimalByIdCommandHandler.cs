using Domain.Models;
using Infrastructure.Database;
using MediatR;

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

            if (animalToUpdate == null)
            {
                return Task.FromResult<Animal>(null!);
            }

            // Update the name, type and if it can play
            animalToUpdate.Name = string.IsNullOrEmpty(request.UpdatedAnimal.Name) ? animalToUpdate.Name : request.UpdatedAnimal.Name;
            animalToUpdate.CanFly = request.UpdatedAnimal.CanFly;
            animalToUpdate.LikesToPlay = request.UpdatedAnimal.LikesToPlay;

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
            switch (animal)
            {
                case Dog dog when _mockDatabase.allDogs.Contains(dog):
                    _mockDatabase.allDogs.Remove(dog);
                    break;
                case Cat cat when _mockDatabase.allCats.Contains(cat):
                    _mockDatabase.allCats.Remove(cat);
                    break;
                case Bird bird when _mockDatabase.allBirds.Contains(bird):
                    _mockDatabase.allBirds.Remove(bird);
                    break;
            }
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
            // Check if Type is null or empty, use existing Type in that case
            string? updatedType = string.IsNullOrEmpty(request.UpdatedAnimal.Type) ? existingAnimal.Type : request.UpdatedAnimal.Type;

            Animal updatedAnimal = updatedType?.ToLower() switch
            {
                "dog" => new Dog(),
                "cat" => new Cat(),
                "bird" => new Bird(),
                _ => new Animal() // Handle unknown types or provide a default type
            };

            // Set common properties
            updatedAnimal.Name = string.IsNullOrEmpty(request.UpdatedAnimal.Name) ? existingAnimal.Name : request.UpdatedAnimal.Name;

            return updatedAnimal;
        }
    }
}
