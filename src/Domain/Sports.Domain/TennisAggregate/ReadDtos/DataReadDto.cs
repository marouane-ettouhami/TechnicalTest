using System.Collections.Generic;

namespace Sports.Domain.TennisAggregate.ReadDtos
{
    public class DataReadDto
    {
        public int Rank { get; set; }
        public int Points { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public List<int> Last { get; set; }
    }
}
