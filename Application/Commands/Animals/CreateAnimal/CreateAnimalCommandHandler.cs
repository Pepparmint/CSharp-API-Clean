using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Animals.CreateAnimal
{
    public sealed class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, Animal>
    {
        private readonly MockDatabase _mockDatabase;

        public CreateAnimalCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Animal> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            // Check if the Type property is null
            if (string.IsNullOrEmpty(request.NewAnimal.Type))
            {
                throw new ArgumentException("Animal type must be specified.");
            }
            // Check if the Name property is null or empty
            if (string.IsNullOrEmpty(request.NewAnimal.Name))
            {
                throw new ArgumentException("Animal name must be specified.");
            }

            // Choose the appropriate derived class based on the provided Type
            Animal newAnimal;
            switch (request.NewAnimal.Type.ToLower())
            {
                case "dog":
                    newAnimal = new Dog();
                    _mockDatabase.allDogs.Add((Dog)newAnimal);
                    break;
                case "cat":
                    newAnimal = new Cat { LikesToPlay = request.NewAnimal.LikesToPlay };
                    _mockDatabase.allCats.Add((Cat)newAnimal);
                    break;
                case "bird":
                    newAnimal = new Bird { CanFly = request.NewAnimal.CanFly };
                    _mockDatabase.allBirds.Add((Bird)newAnimal);
                    break;
                default:
                    newAnimal = new Animal();
                    break;
            }

            // Set common properties
            newAnimal.animalId = Guid.NewGuid();
            newAnimal.Name = request.NewAnimal.Name;

            return Task.FromResult(newAnimal);
        }
    }
}