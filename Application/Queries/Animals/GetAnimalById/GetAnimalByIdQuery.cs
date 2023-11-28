using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Animals.GetAnimalById
{
    public class GetAnimalByIdQuery : IRequest<Animal>
    {
        public Guid Id { get; set; }

        public GetAnimalByIdQuery(Guid animalId)
        {
            Id = animalId;
        }
    }
}
