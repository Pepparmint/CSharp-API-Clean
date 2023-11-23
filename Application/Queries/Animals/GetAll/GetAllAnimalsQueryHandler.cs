using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Animals.GetAll
{
    internal class GetAllAnimalsQueryHandler : IRequestHandler<GetAllAnimalsQuery, List<Animal>>
    {
        private readonly MockDatabase _mockDatabase;

        public GetAllAnimalsQueryHandler(MockDatabase mockDataBase)
        {
            _mockDatabase = mockDataBase;
        }

        public Task<List<Animal>> Handle(GetAllAnimalsQuery request, CancellationToken cancellationToken)
        {
            List<Animal> allAnimalsFromMockDb = _mockDatabase.allAnimals;
            return Task.FromResult(allAnimalsFromMockDb);
        }
    }
}
