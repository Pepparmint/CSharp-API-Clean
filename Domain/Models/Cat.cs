using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Cat : Animal
    {
        public override string Type => "Cat";
        public override string Ability => "This animal has a mysterious and enchanting gaze.";
        public override bool NineLives { get; set; } = true;
        public override int HP { get; set; } = 20; // Health Points
        public override int Defense { get; set; } = 5;
        public override int Attack { get; set; } = 25;
    }
}