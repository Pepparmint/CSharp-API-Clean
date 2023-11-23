using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogCommand : IRequest<Unit>
    {
        public Guid AnimalId { get; set; }

        public DeleteDogCommand(Guid animalId)
        {
            AnimalId = animalId;
        }
    }
}
