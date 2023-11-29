using NUnit.Framework.Constraints;

namespace Application.Dtos
{
    public class AnimalDto
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public bool LikesToPlay { get; set; }
        public bool CanFly { get; set; }
    }
}
