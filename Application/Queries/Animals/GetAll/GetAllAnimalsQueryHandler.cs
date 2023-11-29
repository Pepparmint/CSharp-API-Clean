using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Animals.GetAll
{
    public class GetAllAnimalsQueryHandler : IRequestHandler<GetAllAnimalsQuery, List<Animal>>
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
