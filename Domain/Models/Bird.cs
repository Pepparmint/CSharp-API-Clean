using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Bird : Animal
    {
        public override string Type => "Bird";
        public override string Ability => "This animal has a melodious singing voice.";
        public override bool CanFly { get; set; } = true;
        public override int HP { get; set; } = 15; // Health Points
        public override int Defense { get; set; } = 5;
        public override int Attack { get; set; } = 20;
    }
}
