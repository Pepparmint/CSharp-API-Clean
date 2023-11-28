using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Animals.GetAll
{
    public class GetAllAnimalsQuery : IRequest<List<Animal>>
    {

    }
}
