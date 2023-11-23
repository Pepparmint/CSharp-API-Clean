using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Animals.DeleteAnimal
{
    public class DeleteAnimalCommand : IRequest<Unit>
    {
        public Guid AnimalId { get; set; }

        public DeleteAnimalCommand(Guid animalId)
        {
            AnimalId = animalId;
        }
    }
}
