using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Dog : Animal
    {
        public override string Type => "Dog";
        public override string Ability => "This animal can bark.";
        public override int HP { get; set; } = 220; // Health Points
        public override int Defense { get; set; } = 25;
        public override int Attack { get; set; } = 55;
    }
}
