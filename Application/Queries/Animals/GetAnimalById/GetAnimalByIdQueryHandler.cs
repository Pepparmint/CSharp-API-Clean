using Application.Queries.Animals.GetAll;
using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Animals.GetAnimalById
{
    public class GetAnimalByIdQueryHandler : IRequestHandler<GetAnimalByIdQuery, Animal>
    {
        private readonly MockDatabase _mockDatabase;

        public GetAnimalByIdQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Animal> Handle(GetAnimalByIdQuery request, CancellationToken cancellationToken)
        {
            Animal findAnimal = _mockDatabase.allAnimals.Where(Animal => Animal.animalId == request.Id).FirstOrDefault()!;
            return Task.FromResult(findAnimal);
        }
    }
}
