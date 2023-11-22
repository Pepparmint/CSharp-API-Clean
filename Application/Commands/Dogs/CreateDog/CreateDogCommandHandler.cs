﻿using Application.Queries.Dogs.GetAll;
using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Dogs.CreateDog
{
    internal sealed class CreateDogCommandHandler : IRequestHandler<CreateDogCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public CreateDogCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Dog> Handle(CreateDogCommand request, CancellationToken cancellationToken)
        {
            Dog dogToCreate = new()
            {
                animalId = Guid.NewGuid(),
                Name = request.NewDog.Name
            };

            _mockDatabase.allDogs.Add(dogToCreate);

            return Task.FromResult(dogToCreate);
        }
    }
}
