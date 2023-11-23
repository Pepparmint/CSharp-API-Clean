using NUnit.Framework;
using Infrastructure.Database;
using Application.Commands.Animals.CreateAnimal;
using Application.Commands.Animals.DeleteAnimal;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Animals.GetAnimalById;
using Application.Dtos;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata;

[assembly: InternalsVisibleTo("AnimalTests.cs")]

namespace Test.AnimalTest
{
    
    [TestFixture]
    public class AnimalTests
    {
        private CreateAnimalCommandHandler _createHandler;
        private DeleteAnimalCommandHandler _deleteHandler;
        private GetAnimalByIdQueryHandler _getByIdHandler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize handlers and mock database before each test
            _mockDatabase = new MockDatabase();
            _createHandler = new CreateAnimalCommandHandler(_mockDatabase);
            _deleteHandler = new DeleteAnimalCommandHandler(_mockDatabase);
            _getByIdHandler = new GetAnimalByIdQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task CreateAnimal_ValidData_ReturnsCreatedAnimal()
        {
            // Arrange
            var newAnimalDto = new AnimalDto { Name = "NewAnimal" };
            var createCommand = new CreateAnimalCommand(newAnimalDto);

            // Act
            var createdAnimal = await _createHandler.Handle(createCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(createdAnimal);
            Assert.AreEqual(newAnimalDto.Name, createdAnimal.Name);
        }

        [Test]
        public async Task DeleteAnimal_ValidId_RemovesAnimalFromDatabase()
        {
            // Arrange
            var animalIdToDelete = new Guid("12345678-1234-5678-1234-567812345678");
            var deleteCommand = new DeleteAnimalCommand(animalIdToDelete);

            // Act
            await _deleteHandler.Handle(deleteCommand, CancellationToken.None);
            var animalAfterDeletion = await _getByIdHandler.Handle(new GetAnimalByIdQuery(animalIdToDelete), CancellationToken.None);

            // Assert
            Assert.Null(animalAfterDeletion);
        }
        [Test]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            var invalidAnimalId = Guid.NewGuid();

            var query = new GetAnimalByIdQuery(invalidAnimalId);

            // Act
            var result = await _getByIdHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
