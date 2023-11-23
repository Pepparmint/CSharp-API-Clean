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
        public override string Ability => "This animal can purr";
    }
}
