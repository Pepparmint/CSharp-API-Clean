using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<Animal> allAnimals
        {
            get
            {
                // Combine cats and birds into a single list
                List<Animal> combinedList = new List<Animal>();
                combinedList.AddRange(allDogsFromMockDatabase);
                combinedList.AddRange(allCatsFromMockDatabase);
                combinedList.AddRange(allBirdsFromMockDatabase);
                return combinedList;
            }
            set
            {
                // Split the combined list into cats and birds
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
            new Dog{animalId = Guid.NewGuid(), Name = "Sussy Borkdog"},
            new Dog{animalId = Guid.NewGuid(), Name = "BorkLady"},
            new Dog { animalId = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests"}
        };
        public List<Cat> allCats
        {
            get { return allCatsFromMockDatabase; }
            set { allCatsFromMockDatabase = value; }
        }

        private static List<Cat> allCatsFromMockDatabase = new()
        {
            new Cat{animalId = Guid.NewGuid(), Name = "Puss in Boots"},
            new Cat{animalId = Guid.NewGuid(), Name = "Felix"}
        };

        public List<Bird> allBirds
        {
            get { return allBirdsFromMockDatabase; }
            set { allBirdsFromMockDatabase = value; }
        }

        private static List<Bird> allBirdsFromMockDatabase = new()
        {
            new Bird{animalId = Guid.NewGuid(), Name = "Phoenxi"},
            new Bird{animalId = Guid.NewGuid(), Name = "Bojan"}
        };
    }
}
