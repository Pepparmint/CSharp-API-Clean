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
        public override string Ability => "This animal can fly ";
    }
}
