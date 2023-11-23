using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogCommandHandler : IRequestHandler<DeleteDogCommand, Unit>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteDogCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Unit> Handle(DeleteDogCommand request, CancellationToken cancellationToken)
        {
            // Find and remove the dog from the database
            Dog dogToDelete = _mockDatabase.allDogs.FirstOrDefault(dog => dog.animalId == request.AnimalId)!;

            if (dogToDelete != null)
            {
                _mockDatabase.allDogs.Remove(dogToDelete);
            }

            return Task.FromResult(Unit.Value);
        }
    }
}
