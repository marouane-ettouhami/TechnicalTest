using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sports.Domain.TennisAggregate.Entities
{
    public class Data
    {
        [Key]
        public int DataId { get; set; }
        public int Rank { get; set; }
        public int Points { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public List<LastGames> Last { get; set; }
    }
}
