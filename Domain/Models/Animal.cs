using Microsoft.AspNetCore.Components.Web.Virtualization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Animal
    {
        public Guid animalId { get; set; }
        public string? Name { get; set; }
        public virtual string? Type { get; }
        public virtual string? Ability { get; }
        public virtual bool CanFly { get; set; }
        public virtual bool LikesToPlay { get; set; }
        public virtual int HP { get; set; } = 100; // Health Points
        public virtual int Defense { get; set; } = 10;
        public virtual int Attack { get; set; } = 15;
    }
}
