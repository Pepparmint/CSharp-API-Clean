using NUnit.Framework;
using Infrastructure.Database;
using Application.Commands.Animals.CreateAnimal;
using Application.Commands.Animals.DeleteAnimal;
using Application.Commands.Animals.UpdateAnimal;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Animals.GetAnimalById;
using Application.Dtos;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata;
using Domain.Models;
using Application.Queries.Animals.GetAll;


[assembly: InternalsVisibleTo("AnimalTests.cs")]

namespace Test.AnimalTest
{
    
    [TestFixture]
    public class AnimalTests
    {
        private CreateAnimalCommandHandler _createHandler;
        private DeleteAnimalCommandHandler _deleteHandler;
        private UpdateAnimalByIdCommandHandler _updateHandler;
        private GetAnimalByIdQueryHandler _getByIdHandler;
        private GetAllAnimalsQueryHandler _getAllHandler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize handlers and mock database before each test
            _mockDatabase = new MockDatabase();
            _createHandler = new CreateAnimalCommandHandler(_mockDatabase);
            _updateHandler = new UpdateAnimalByIdCommandHandler(_mockDatabase);
            _deleteHandler = new DeleteAnimalCommandHandler(_mockDatabase);
            _getByIdHandler = new GetAnimalByIdQueryHandler(_mockDatabase);
            _getAllHandler = new GetAllAnimalsQueryHandler(_mockDatabase);
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
        public async Task UpdateAnimal_ValidData_ReturnsUpdatedAnimal()
        {
            // Arrange
            var animalIdToUpdate = new Guid("12345678-1234-5678-1234-567812345677");
            var updatedAnimalDto = new AnimalDto { Name = "UpdatedAnimal" };
            var updateCommand = new UpdateAnimalByIdCommand(updatedAnimalDto, animalIdToUpdate);

            // Act
            var updatedAnimal = await _updateHandler.Handle(updateCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(updatedAnimal);
            Assert.AreEqual(updatedAnimalDto.Name, updatedAnimal.Name);
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
        public async Task GetAllAnimals_ReturnsAllAnimals()
        {
            // Arrange - Assuming you have some animals in your mock database
            var expectedAnimalCount = _mockDatabase.allAnimals.Count;
            var query = new GetAllAnimalsQuery();

            // Act
            var allAnimals = await _getAllHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(allAnimals);
            Assert.AreEqual(expectedAnimalCount, allAnimals.Count);
            // Add more assertions if needed based on the properties you expect from the animals.
        }

        [Test]
        public async Task Handle_ValidId_ReturnsCorrectAnimal()
        {
            // Arrange
            var animalId = new Guid("12345678-1234-5678-1234-567812345679");

            var query = new GetAnimalByIdQuery(animalId);

            // Act
            var result = await _getByIdHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.animalId, Is.EqualTo(animalId));
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
