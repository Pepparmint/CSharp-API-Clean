using Domain.Models;
using MediatR;

namespace Application.Queries.Animals.GetAll
{
    public class GetAllAnimalsQuery : IRequest<List<Animal>>
    {

    }
}
