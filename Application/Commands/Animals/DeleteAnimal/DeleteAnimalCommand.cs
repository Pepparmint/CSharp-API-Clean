using MediatR;

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
