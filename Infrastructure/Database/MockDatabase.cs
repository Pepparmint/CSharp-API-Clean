using Domain.Models;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<Animal> allAnimals
        {
            get
            {
                // Combine lists into a single list
                List<Animal> combinedList = new List<Animal>();
                combinedList.AddRange(allDogsFromMockDatabase);
                combinedList.AddRange(allCatsFromMockDatabase);
                combinedList.AddRange(allBirdsFromMockDatabase);
                return combinedList;
            }
            set
            {
                // Split the combined list into single lists
                allDogsFromMockDatabase = value.OfType<Dog>().ToList();
                allCatsFromMockDatabase = value.OfType<Cat>().ToList();
                allBirdsFromMockDatabase = value.OfType<Bird>().ToList();
            }
        }
        public List<Dog> allDogs
        {
            get { return allDogsFromMockDatabase; }
            set { allDogsFromMockDatabase = value; }
        }

        private static List<Dog> allDogsFromMockDatabase = new()
        {
            new Dog{animalId = Guid.NewGuid(), Name = "Sussy Borkdog"}
        };
        public List<Cat> allCats
        {
            get { return allCatsFromMockDatabase; }
            set { allCatsFromMockDatabase = value; }
        }

        private static List<Cat> allCatsFromMockDatabase = new()
        {
            new Cat{animalId = Guid.NewGuid(), Name = "Puss in Boots"}
        };

        public List<Bird> allBirds
        {
            get { return allBirdsFromMockDatabase; }
            set { allBirdsFromMockDatabase = value; }
        }

        private static List<Bird> allBirdsFromMockDatabase = new()
        {
            new Bird{animalId = Guid.NewGuid(), Name = "Phoenix"},
            new Bird{animalId = new Guid("12345678-1234-5678-1234-567812345678"), Name = "AnimalTestDelete"},
            new Bird{animalId = new Guid("12345678-1234-5678-1234-567812345679"), Name = "AnimalTestReturnCorrectAnimal"},
            new Bird{animalId = new Guid("12345678-1234-5678-1234-567812345677"), Name = "AnimalTestUpdate"}
        };
    }
}
