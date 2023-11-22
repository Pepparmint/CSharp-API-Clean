using MediatR;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Database;

namespace Application.Queries.Dogs.GetDogById
{
    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Dog>
    {
        private readonly MockDatabase _mockDataBase;

        public GetDogByIdQueryHandler(MockDatabase mockDataBase)
        {
            _mockDataBase = mockDataBase;
        }
        public Task<Dog> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            Dog findDog = _mockDataBase.allDogs.Where(Dog => Dog.animalId == request.Id).FirstOrDefault()!;
            return Task.FromResult(findDog);
        }
    }
}
