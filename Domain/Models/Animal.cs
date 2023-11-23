﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Animal
    {
        public Guid animalId { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual string Type { get; } = string.Empty;
        public virtual string Ability { get; } = string.Empty;
    }
}
