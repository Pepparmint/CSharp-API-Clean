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
        public List<Dog> allDogs
        {
            get { return allDogsFromMockDatabase; }
            set { allDogsFromMockDatabase = value; }
        }

        private static List<Dog> allDogsFromMockDatabase = new()
        {
            new Dog
            {
                animalId = Guid.NewGuid(), Name = "God King Tobias"
            },
            new Dog
            {
                animalId = Guid.NewGuid(), Name = "Sussy Borkdog"
            },
            new Dog
            {
                animalId = Guid.NewGuid(), Name = "BorkLady"
            },
            new Dog
            {
                animalId = Guid.NewGuid(), Name = "Max The Dward Pincher"
            },
            new Dog
            {
                animalId = Guid.NewGuid(), Name = "Dawg Bojan"
            },
        };
    }
}
