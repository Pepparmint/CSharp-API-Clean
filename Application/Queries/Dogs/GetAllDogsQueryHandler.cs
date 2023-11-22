using MediatR;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Database;

namespace Application.Queries.Dogs
{
    internal class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly MockDatabase _mockDataBase;

        public GetAllDogsQueryHandler(MockDatabase mockDataBase)
        {
            _mockDataBase = mockDataBase;
        }

        public Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            List<Dog> allDogsFromMockDb = _mockDataBase.allDogs;
            return Task.FromResult(allDogsFromMockDb);
        }
    }
}
