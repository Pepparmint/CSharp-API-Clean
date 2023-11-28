using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.Animals.CreateAnimal
{
    public class CreateAnimalCommand : IRequest<Animal>
    {
        public CreateAnimalCommand(AnimalDto newAnimal)
        {
            NewAnimal = newAnimal;
        }
        public AnimalDto NewAnimal { get; }
    }
}
