﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Dog : Animal
    {
        public override string Ability()
        {
            return "This animal can bark at Bojan";
        }
    }
}
