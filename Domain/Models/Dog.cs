﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Dog : Animal
    {
        public string Bark()
        {
            return "This animal can bark at Bojan";
        }

    }
}
